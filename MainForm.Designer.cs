namespace Flying47
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TTimer = new System.Windows.Forms.Timer(this.components);
            this.LB_Running = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CheckpointVal = new System.Windows.Forms.Label();
            this.InCutsceneBool = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ShouldReload = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TTimer
            // 
            this.TTimer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // LB_Running
            // 
            this.LB_Running.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_Running.Dock = System.Windows.Forms.DockStyle.Top;
            this.LB_Running.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Running.ForeColor = System.Drawing.Color.Red;
            this.LB_Running.Location = new System.Drawing.Point(0, 0);
            this.LB_Running.Name = "LB_Running";
            this.LB_Running.Size = new System.Drawing.Size(455, 24);
            this.LB_Running.TabIndex = 1;
            this.LB_Running.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_Running.Click += new System.EventHandler(this.LB_Running_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.CheckpointVal, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.InCutsceneBool, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(247, 63);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // CheckpointVal
            // 
            this.CheckpointVal.AutoSize = true;
            this.CheckpointVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckpointVal.Location = new System.Drawing.Point(4, 35);
            this.CheckpointVal.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.CheckpointVal.Name = "CheckpointVal";
            this.CheckpointVal.Size = new System.Drawing.Size(47, 13);
            this.CheckpointVal.TabIndex = 4;
            this.CheckpointVal.Text = "#####";
            this.CheckpointVal.Click += new System.EventHandler(this.label2_Click);
            // 
            // InCutsceneBool
            // 
            this.InCutsceneBool.AutoSize = true;
            this.InCutsceneBool.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InCutsceneBool.Location = new System.Drawing.Point(127, 35);
            this.InCutsceneBool.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.InCutsceneBool.Name = "InCutsceneBool";
            this.InCutsceneBool.Size = new System.Drawing.Size(47, 13);
            this.InCutsceneBool.TabIndex = 1;
            this.InCutsceneBool.Text = "#####";
            this.InCutsceneBool.Click += new System.EventHandler(this.L_X_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 1);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Checkpoint Value";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 1);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Are you in a cutscene?";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 92);
            this.panel1.TabIndex = 42;
            // 
            // ShouldReload
            // 
            this.ShouldReload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ShouldReload.Dock = System.Windows.Forms.DockStyle.Top;
            this.ShouldReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShouldReload.ForeColor = System.Drawing.Color.Red;
            this.ShouldReload.Location = new System.Drawing.Point(0, 24);
            this.ShouldReload.Name = "ShouldReload";
            this.ShouldReload.Size = new System.Drawing.Size(455, 24);
            this.ShouldReload.TabIndex = 43;
            this.ShouldReload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ShouldReload.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 116);
            this.Controls.Add(this.ShouldReload);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LB_Running);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Dead Space 3 Cutscene Skip Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer TTimer;
        private System.Windows.Forms.Label LB_Running;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label InCutsceneBool;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ShouldReload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CheckpointVal;
    }
}

