﻿using MemoryReads64;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
        public MainForm()
        {
            InitializeComponent();
            CheckpointLookup.initialiseSwapTable();
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
                    LB_Running.Text = processName + " is running";
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

                    if(!byteArrayEquals(cpHex, lastcpHex))
                    {
                        lastcpHex = cpHex;
                        cutscenesSeen = 0;
                    }

                    ShouldReload.Text = shouldSkip ? "Waiting for cutscene to skip" : "Checkpoint reload to skip this cutscene!";
                    ShouldReload.ForeColor = shouldSkip ? Color.Red : Color.Green;
                    StringBuilder hex = new StringBuilder(cpHex.Length * 2);
                    foreach (byte b in cpHex)
                    {
                        hex.AppendFormat("{0:x2} ", b);
                    }
                    CheckpointVal.Text = hex.ToString();
                   

                    InCutsceneBool.Text = inCutsceneInt == 0 ? "True" : "False";
                    TTimer.Interval = 100;
                }
                else
                {
                    // The game process has not been found, reseting values.
                    LB_Running.Text = processName + " is not running";
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
            InCutsceneBool.Text = "False";
            ShouldReload.Text =  "Waiting for cutscene to skip";
            ShouldReload.ForeColor = Color.Red;
            CheckpointVal.Text = "######";
        }

        private void L_X_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LB_Running_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
