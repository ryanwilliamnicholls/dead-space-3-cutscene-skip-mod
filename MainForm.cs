using MemoryReads64;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Flying47
{
    public partial class MainForm : Form
    {
        // Other variables.
        Process myProcess;
        public string processName = "deadspace3";

        byte[] cpHex;
        byte[] lastcpHex;
        Pointer checkpointHex = new Pointer("", 14605032, new int[0]);
        bool shouldSkip = true;
        bool shouldIncrementCounter = true;
        int inCutsceneInt = 1;
        Pointer inCutscene= new Pointer("", 15176212, new int[] {304, 268, 260, 420, 352});


        float readCoordX = 0;
        float readCoordY = 0;
        float readCoordZ = 0;

        int cutscenesSeen = 0;

        PositionSet_Pointer positionAddress = new PositionSet_Pointer(
            new Pointer("", 0x00E10060, new int[] { 0x380, 0xB0 }), 4, true);
        /*------------------
        -- INITIALIZATION --
        ------------------*/
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public static String version = "1.1.1";

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            } else if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, new Point(e.X, e.Y));
            }
        }

        public MainForm()
        {
            InitializeComponent();
            CheckpointLookup.initialiseSwapTable();
            toolStripVersion.Text = "Version " + version;
            this.TopMost = true;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                    TTimer.Start();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
        }

        bool foundProcess = false;

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {

                myProcess = Process.GetProcessesByName(processName).FirstOrDefault();
                if (myProcess != null)
                {
                    if (foundProcess == false)
                    {
                        TTimer.Interval = 1000;
                    }

                    foundProcess = true;
                }
                else
                {
                    foundProcess = false;
                }


                if (foundProcess)
                {
                    // The game is running, ready for memory reading.
                    LB_Running.Text = "Dead Space 3 is running";
                    LB_Running.ForeColor = Color.Green;

                    cpHex = Trainer.ReadPointerByteArray(myProcess, checkpointHex, 16);
                    inCutsceneInt = Trainer.ReadPointerInteger(myProcess, inCutscene);
                    positionAddress.ReadSet(myProcess, out readCoordX, out readCoordY, out readCoordZ);

                    if (!cpHex[0].Equals(0x00) && readCoordX == 0 && readCoordY == 0 && readCoordZ == 0 && inCutsceneInt != 0)
                    {
                        //player has checkpoint reloaded when not in a cutscene, reset the counter for checkpoints they have seen in this checkpoint
                        cutscenesSeen = 0;
                    }

                    if(cpHex[0].Equals(0x00))
                    {
                        shouldSkip = false; // dont skip cutscenes when loading to and from the main menu
                    }

                    if (inCutsceneInt == 0 && shouldSkip && CheckpointLookup.getCutsceneCountForCheckpoint(cpHex) == cutscenesSeen)
                    {
                        bool val = CheckpointLookup.swapCheckPointIfInTable(myProcess, checkpointHex, cpHex);
                        shouldSkip = !val;
                        if (shouldSkip) 
                        {
                            // if the swap is called and does not swap, just increment the cutscene counter
                            cutscenesSeen++;
                        } else
                        {
                            // if the swap is called and does swap, stop the counter from incrementing til the checkpoint is reloaded
                            shouldIncrementCounter = false;
                        }
                    } else
                    {
                        if(inCutsceneInt != 0)
                        {
                            shouldSkip = true;
                            shouldIncrementCounter = true;
                        } else if (shouldIncrementCounter == true) // if your in a cutscene, and havent already incremented the counter for this cutscene, increment it
                        {
                            cutscenesSeen++;
                            shouldIncrementCounter = false;
                        }
                    }

                    //reset the cutscene count when the checkpoint changes
                    if(!byteArrayEquals(cpHex, lastcpHex))
                    {
                        lastcpHex = cpHex;
                        cutscenesSeen = 0;
                    }

                    //Checkpoint specific fixes

                    //Before final boss, first time you enter this cutscene the checkpoint fires in the cutscene itself, but the checkpoint loads you before the cutscene
                    // this leads to different cutscene counts if you die or reload in that jump sequence.
                    // this will increment the value up to what its meant to be in the first instance
                    if(byteArrayEquals(cpHex, new byte[] { 0xDB, 0xFE, 0xA0, 0x31, 0x50, 0xE8, 0x28, 0xF6, 0x59, 0x4D, 0x55, 0x52, 0x50, 0x48, 0x59, 0x30 }) && inCutsceneInt == 0 && cutscenesSeen == 0)
                    {
                        cutscenesSeen++;
                    }

                    ShouldReload.Text = (shouldSkip || cpHex[0].Equals(0x00)) ? "Waiting for cutscene to skip" : "Checkpoint reload to skip this cutscene!";
                    ShouldReload.ForeColor = (shouldSkip || cpHex[0].Equals(0x00)) ? Color.Red : Color.Green;
                    StringBuilder hex = new StringBuilder(cpHex.Length * 2);
                    foreach (byte b in cpHex)
                    {
                        hex.AppendFormat("{0:x2} ", b);
                    }
                   

                    TTimer.Interval = 100;
                }
                else
                {
                    // The game process has not been found, reseting values.
                    LB_Running.Text = "Dead Space 3 is not running";
                    LB_Running.ForeColor = Color.Red;
                    ResetValues();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private bool byteArrayEquals(byte[] left, byte[] right)
        {
            if (left == null || right == null)
            {
                return left == right;
            }
            return left.SequenceEqual(right);
        }

        // Used to reset all the values.
        private void ResetValues()
        {
            ShouldReload.Text =  "Waiting for cutscene to skip";
            ShouldReload.ForeColor = Color.Red;
        }


        private void LB_Running_Click(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
