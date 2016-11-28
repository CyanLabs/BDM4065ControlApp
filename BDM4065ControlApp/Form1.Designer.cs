namespace BDM4065ControlApp
{
    public partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PowerStateGroupBox = new System.Windows.Forms.GroupBox();
            this.PowerStateOnButton = new System.Windows.Forms.Button();
            this.PowerStateOffButton = new System.Windows.Forms.Button();
            this.VolumeUpDown = new System.Windows.Forms.NumericUpDown();
            this.VolumeGroupBox = new System.Windows.Forms.GroupBox();
            this.VolumeResetButton = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PowerStateGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeUpDown)).BeginInit();
            this.VolumeGroupBox.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PowerStateGroupBox
            // 
            this.PowerStateGroupBox.Controls.Add(this.PowerStateOnButton);
            this.PowerStateGroupBox.Controls.Add(this.PowerStateOffButton);
            this.PowerStateGroupBox.Location = new System.Drawing.Point(12, 12);
            this.PowerStateGroupBox.Name = "PowerStateGroupBox";
            this.PowerStateGroupBox.Size = new System.Drawing.Size(137, 52);
            this.PowerStateGroupBox.TabIndex = 6;
            this.PowerStateGroupBox.TabStop = false;
            this.PowerStateGroupBox.Text = "Power State";
            // 
            // PowerStateOnButton
            // 
            this.PowerStateOnButton.Location = new System.Drawing.Point(71, 19);
            this.PowerStateOnButton.Name = "PowerStateOnButton";
            this.PowerStateOnButton.Size = new System.Drawing.Size(56, 24);
            this.PowerStateOnButton.TabIndex = 1;
            this.PowerStateOnButton.Text = "On";
            this.PowerStateOnButton.UseVisualStyleBackColor = true;
            this.PowerStateOnButton.Click += new System.EventHandler(this.PowerStateOnButton_Click);
            // 
            // PowerStateOffButton
            // 
            this.PowerStateOffButton.Location = new System.Drawing.Point(7, 19);
            this.PowerStateOffButton.Name = "PowerStateOffButton";
            this.PowerStateOffButton.Size = new System.Drawing.Size(57, 24);
            this.PowerStateOffButton.TabIndex = 0;
            this.PowerStateOffButton.Text = "Off";
            this.PowerStateOffButton.UseVisualStyleBackColor = true;
            this.PowerStateOffButton.Click += new System.EventHandler(this.PowerStateOffButton_Click);
            // 
            // VolumeUpDown
            // 
            this.VolumeUpDown.Location = new System.Drawing.Point(81, 20);
            this.VolumeUpDown.Name = "VolumeUpDown";
            this.VolumeUpDown.Size = new System.Drawing.Size(50, 20);
            this.VolumeUpDown.TabIndex = 8;
            this.VolumeUpDown.ValueChanged += new System.EventHandler(this.VolumeUpDown_ValueChanged);
            // 
            // VolumeGroupBox
            // 
            this.VolumeGroupBox.Controls.Add(this.VolumeResetButton);
            this.VolumeGroupBox.Controls.Add(this.VolumeUpDown);
            this.VolumeGroupBox.Location = new System.Drawing.Point(12, 70);
            this.VolumeGroupBox.Name = "VolumeGroupBox";
            this.VolumeGroupBox.Size = new System.Drawing.Size(137, 46);
            this.VolumeGroupBox.TabIndex = 9;
            this.VolumeGroupBox.TabStop = false;
            this.VolumeGroupBox.Text = "Volume";
            // 
            // VolumeResetButton
            // 
            this.VolumeResetButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.VolumeResetButton.Location = new System.Drawing.Point(6, 19);
            this.VolumeResetButton.Name = "VolumeResetButton";
            this.VolumeResetButton.Size = new System.Drawing.Size(50, 22);
            this.VolumeResetButton.TabIndex = 9;
            this.VolumeResetButton.Text = "Reset";
            this.VolumeResetButton.UseVisualStyleBackColor = true;
            this.VolumeResetButton.Click += new System.EventHandler(this.VolumeResetButton_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "BDM4065 Remote";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(93, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(163, 126);
            this.Controls.Add(this.VolumeGroupBox);
            this.Controls.Add(this.PowerStateGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Remote";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PowerStateGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VolumeUpDown)).EndInit();
            this.VolumeGroupBox.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox PowerStateGroupBox;
        private System.Windows.Forms.Button PowerStateOnButton;
        private System.Windows.Forms.Button PowerStateOffButton;
        private System.Windows.Forms.NumericUpDown VolumeUpDown;
        private System.Windows.Forms.GroupBox VolumeGroupBox;
        private System.Windows.Forms.Button VolumeResetButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}