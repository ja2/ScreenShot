namespace ScreenShot
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label2;
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkFSWin = new System.Windows.Forms.CheckBox();
            this.txtFSKey = new System.Windows.Forms.TextBox();
            this.chkFSShift = new System.Windows.Forms.CheckBox();
            this.chkFSAlt = new System.Windows.Forms.CheckBox();
            this.chkFSCtrl = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAWWin = new System.Windows.Forms.CheckBox();
            this.txtAWKey = new System.Windows.Forms.TextBox();
            this.chkAWShift = new System.Windows.Forms.CheckBox();
            this.chkAWAlt = new System.Windows.Forms.CheckBox();
            this.chkAWCtrl = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkLaunchOnLogin = new System.Windows.Forms.CheckBox();
            this.chkRightClick = new System.Windows.Forms.CheckBox();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ScreenShot";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(376, 192);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(52, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(376, 221);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(52, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Location = new System.Drawing.Point(364, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(64, 64);
            this.panel1.TabIndex = 20;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(376, 250);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(52, 23);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkFSWin);
            this.groupBox1.Controls.Add(label3);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.txtFSKey);
            this.groupBox1.Controls.Add(this.chkFSShift);
            this.groupBox1.Controls.Add(this.chkFSAlt);
            this.groupBox1.Controls.Add(this.chkFSCtrl);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 165);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Full Screen Hotkey";
            // 
            // chkFSWin
            // 
            this.chkFSWin.AutoSize = true;
            this.chkFSWin.Location = new System.Drawing.Point(79, 128);
            this.chkFSWin.Name = "chkFSWin";
            this.chkFSWin.Size = new System.Drawing.Size(45, 17);
            this.chkFSWin.TabIndex = 21;
            this.chkFSWin.Text = "Win";
            this.chkFSWin.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(27, 60);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(49, 13);
            label3.TabIndex = 22;
            label3.Text = "Modifiers";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(27, 36);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(25, 13);
            label1.TabIndex = 18;
            label1.Text = "Key";
            // 
            // txtFSKey
            // 
            this.txtFSKey.Location = new System.Drawing.Point(79, 29);
            this.txtFSKey.MaxLength = 1;
            this.txtFSKey.Name = "txtFSKey";
            this.txtFSKey.Size = new System.Drawing.Size(29, 20);
            this.txtFSKey.TabIndex = 16;
            // 
            // chkFSShift
            // 
            this.chkFSShift.AutoSize = true;
            this.chkFSShift.Location = new System.Drawing.Point(79, 59);
            this.chkFSShift.Name = "chkFSShift";
            this.chkFSShift.Size = new System.Drawing.Size(47, 17);
            this.chkFSShift.TabIndex = 17;
            this.chkFSShift.Text = "Shift";
            this.chkFSShift.UseVisualStyleBackColor = true;
            // 
            // chkFSAlt
            // 
            this.chkFSAlt.AutoSize = true;
            this.chkFSAlt.Location = new System.Drawing.Point(79, 82);
            this.chkFSAlt.Name = "chkFSAlt";
            this.chkFSAlt.Size = new System.Drawing.Size(38, 17);
            this.chkFSAlt.TabIndex = 19;
            this.chkFSAlt.Text = "Alt";
            this.chkFSAlt.UseVisualStyleBackColor = true;
            // 
            // chkFSCtrl
            // 
            this.chkFSCtrl.AutoSize = true;
            this.chkFSCtrl.Location = new System.Drawing.Point(79, 105);
            this.chkFSCtrl.Name = "chkFSCtrl";
            this.chkFSCtrl.Size = new System.Drawing.Size(41, 17);
            this.chkFSCtrl.TabIndex = 20;
            this.chkFSCtrl.Text = "Ctrl";
            this.chkFSCtrl.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAWWin);
            this.groupBox2.Controls.Add(label4);
            this.groupBox2.Controls.Add(label5);
            this.groupBox2.Controls.Add(this.txtAWKey);
            this.groupBox2.Controls.Add(this.chkAWShift);
            this.groupBox2.Controls.Add(this.chkAWAlt);
            this.groupBox2.Controls.Add(this.chkAWCtrl);
            this.groupBox2.Location = new System.Drawing.Point(177, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 165);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Active Window Hotkey";
            // 
            // chkAWWin
            // 
            this.chkAWWin.AutoSize = true;
            this.chkAWWin.Location = new System.Drawing.Point(79, 128);
            this.chkAWWin.Name = "chkAWWin";
            this.chkAWWin.Size = new System.Drawing.Size(45, 17);
            this.chkAWWin.TabIndex = 21;
            this.chkAWWin.Text = "Win";
            this.chkAWWin.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(27, 60);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(49, 13);
            label4.TabIndex = 22;
            label4.Text = "Modifiers";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(27, 36);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(25, 13);
            label5.TabIndex = 18;
            label5.Text = "Key";
            // 
            // txtAWKey
            // 
            this.txtAWKey.Location = new System.Drawing.Point(79, 29);
            this.txtAWKey.MaxLength = 1;
            this.txtAWKey.Name = "txtAWKey";
            this.txtAWKey.Size = new System.Drawing.Size(29, 20);
            this.txtAWKey.TabIndex = 16;
            // 
            // chkAWShift
            // 
            this.chkAWShift.AutoSize = true;
            this.chkAWShift.Location = new System.Drawing.Point(79, 59);
            this.chkAWShift.Name = "chkAWShift";
            this.chkAWShift.Size = new System.Drawing.Size(47, 17);
            this.chkAWShift.TabIndex = 17;
            this.chkAWShift.Text = "Shift";
            this.chkAWShift.UseVisualStyleBackColor = true;
            // 
            // chkAWAlt
            // 
            this.chkAWAlt.AutoSize = true;
            this.chkAWAlt.Location = new System.Drawing.Point(79, 82);
            this.chkAWAlt.Name = "chkAWAlt";
            this.chkAWAlt.Size = new System.Drawing.Size(38, 17);
            this.chkAWAlt.TabIndex = 19;
            this.chkAWAlt.Text = "Alt";
            this.chkAWAlt.UseVisualStyleBackColor = true;
            // 
            // chkAWCtrl
            // 
            this.chkAWCtrl.AutoSize = true;
            this.chkAWCtrl.Location = new System.Drawing.Point(79, 105);
            this.chkAWCtrl.Name = "chkAWCtrl";
            this.chkAWCtrl.Size = new System.Drawing.Size(41, 17);
            this.chkAWCtrl.TabIndex = 20;
            this.chkAWCtrl.Text = "Ctrl";
            this.chkAWCtrl.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(label6);
            this.groupBox3.Controls.Add(this.chkLaunchOnLogin);
            this.groupBox3.Controls.Add(label2);
            this.groupBox3.Controls.Add(this.chkRightClick);
            this.groupBox3.Location = new System.Drawing.Point(12, 183);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 90);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(27, 59);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(89, 13);
            label6.TabIndex = 22;
            label6.Text = "Launch On Login";
            // 
            // chkLaunchOnLogin
            // 
            this.chkLaunchOnLogin.AutoSize = true;
            this.chkLaunchOnLogin.Location = new System.Drawing.Point(126, 58);
            this.chkLaunchOnLogin.Name = "chkLaunchOnLogin";
            this.chkLaunchOnLogin.Size = new System.Drawing.Size(15, 14);
            this.chkLaunchOnLogin.TabIndex = 20;
            this.chkLaunchOnLogin.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(27, 30);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(82, 13);
            label2.TabIndex = 21;
            label2.Text = "Icon Right Click";
            // 
            // chkRightClick
            // 
            this.chkRightClick.AutoSize = true;
            this.chkRightClick.Location = new System.Drawing.Point(126, 29);
            this.chkRightClick.Name = "chkRightClick";
            this.chkRightClick.Size = new System.Drawing.Size(15, 14);
            this.chkRightClick.TabIndex = 19;
            this.chkRightClick.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(444, 291);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScreenShot Settings";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkFSWin;
        private System.Windows.Forms.TextBox txtFSKey;
        private System.Windows.Forms.CheckBox chkFSShift;
        private System.Windows.Forms.CheckBox chkFSAlt;
        private System.Windows.Forms.CheckBox chkFSCtrl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAWWin;
        private System.Windows.Forms.TextBox txtAWKey;
        private System.Windows.Forms.CheckBox chkAWShift;
        private System.Windows.Forms.CheckBox chkAWAlt;
        private System.Windows.Forms.CheckBox chkAWCtrl;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkLaunchOnLogin;
        private System.Windows.Forms.CheckBox chkRightClick;
    }
}

