using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace ScreenShot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //Check already runnning (only within the current session)
                var myProc = Process.GetCurrentProcess();
                if (Process.GetProcessesByName("ScreenShot").Any(p => p.Id != myProc.Id && p.SessionId == myProc.SessionId))
                    throw new InvalidOperationException("ScreenShot is already running");
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ScreenShot", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
