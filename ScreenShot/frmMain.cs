using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using Newtonsoft.Json;
using ScreenShot.Code;

namespace ScreenShot
{
    public partial class frmMain : Form
    {

        string _configPath;
        Worker _worker;
        
        public frmMain()
        {
            InitializeComponent();
        }

        #region Window State Management

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {

            switch (e.Button) 
            {
                case System.Windows.Forms.MouseButtons.Left:
                    //On single click show dialog
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    break;

                case System.Windows.Forms.MouseButtons.Right:
                    //Take screen grab if appropriate on double click
                    if (_worker.Config.EnableRightClick) _worker.TakeScreenShot();
                    break;

                default:
                    //Do nothing
                    break;
            }

        }
        
        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }

        }

        #endregion


        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                LoadSettings();
                InitWorker();
                ShowInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ScreenShot", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void InitWorker()
        {
            //Set the keyboard hook
            _worker.SetHook();

            //Set the event handler
            _worker.ScreenShotComplete += _worker_ScreenShotComplete;
        
        }

        private void LoadSettings()
        {

            //Set the config filename
            _configPath = System.IO.Path.Combine(Environment.CurrentDirectory, "ScreenShotSettings.config");

            //Start up the worker
            var config = ScreenShotConfiguration.Load(_configPath);
            _worker = new Worker(config);
            
            //Clear out existing bindings.
            foreach (Control c in this.Controls)
                c.DataBindings.Clear();

            //Set the screen control bindings
            txtKey.DataBindings.Add("Text", _worker.Config, "Key");
            chkAlt.DataBindings.Add("Checked", _worker.Config, "Alt");
            chkShift.DataBindings.Add("Checked", _worker.Config, "Shift");
            chkCtrl.DataBindings.Add("Checked", _worker.Config, "Ctrl");
            chkWin.DataBindings.Add("Checked", _worker.Config, "Win");
            chkRightClick.DataBindings.Add("Checked", _worker.Config, "EnableRightClick");
            chkLaunchOnLogin.DataBindings.Add("Checked", _worker.Config, "LaunchOnLogin");

        }

        private void ShowInfo()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("ScreenShot enabled.");
            sb.AppendLine(_worker.Config.ToString());
            sb.AppendLine("Left Click for settings.");

            notifyIcon.ShowBalloonTip(200, "ScreenShot", sb.ToString(), ToolTipIcon.Info);
        }

        void _worker_ScreenShotComplete(object sender, EventArgs e)
        {            
            notifyIcon.ShowBalloonTip(200,"ScreenShot","ScreenShot saved to clipboard",ToolTipIcon.Info);
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Save the file
                _worker.Config.Save(_configPath);

                //Update the hook
                _worker.SetHook();               

                //Show the update
                ShowInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ScreenShot", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                LoadSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ScreenShot", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Click OK to close. If you meant to hide the settings window, click Cancel, then click Minimize",
                "ScreenShot closing",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel) e.Cancel = true;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ja2/ScreenShot");
        }

        
    }
}
