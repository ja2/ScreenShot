using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jon.ScreenGrabber
{
    public partial class frmMain : Form
    {

        string _configPath;
        Grabber _grabber;
        
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
                    if (_grabber.Config.EnableRightClick) _grabber.GrabScreen();
                    break;

                default:
                    //Do nothing
                    break;
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
            this.Hide();
            LoadSettings();
        }

        private void LoadSettings()
        {

            //Set the config filename
            _configPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Jon.ScreenGrabber.config.xml");

            //Load the configuration
            var config = SerializationHelper.DeserializeFromXMLDoc<ScreenGrabberConfiguration>(_configPath);

            //Set the screen controls
            txtKey.Text = config.Key;
            chkAlt.Checked = config.Alt;
            chkShift.Checked = config.Shift;
            chkCtrl.Checked = config.Ctrl;
            chkRightClick.Checked = config.EnableRightClick;

            //Start up the grabber
            _grabber = new Grabber(config);
            _grabber.GrabComplete += new Grabber.GrabCompleteHandler(_grabber_GrabComplete);
        }

        void _grabber_GrabComplete(object sender, EventArgs e)
        {            
            notifyIcon.ShowBalloonTip(200,"Jon.ScreenGrabber","Screen grabbed to clipboard",ToolTipIcon.Info);
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Set the config from the screen controls
            var cfg = _grabber.Config;
            cfg.Key = txtKey.Text.ToUpper();
            cfg.Alt = chkAlt.Checked;
            cfg.Shift = chkShift.Checked;
            cfg.Ctrl = chkCtrl.Checked;
            cfg.EnableRightClick = chkRightClick.Checked;

            //Save the file
            SerializationHelper.SerializeToXMLDoc(_configPath, cfg);
            
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Click OK to close. If you meant to hide the settings window, click Cancel, then click Hide",
                "Jon.ScreenGrabber closing",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel) e.Cancel = true;
        }



    }
}
