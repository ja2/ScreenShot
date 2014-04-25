using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Win32;
using System.Web.Script.Serialization;

namespace ScreenShot

    
{


    /// <summary>
    /// Configuration class to handle persistence of settings
    /// </summary>
    /// <remarks>
    /// Includes databinding functionality
    /// </remarks>
    public class ScreenShotConfiguration: INotifyPropertyChanged
    {

        public ScreenShotKeyConfiguration FullScreenHotKey { get; set; }
        public ScreenShotKeyConfiguration ActiveWindowHotKey {get;set;}

        /// <summary>
        /// Use the Win key modifier
        /// </summary>
        public bool EnableRightClick
        {
            get { return _enableRightClick; }
            set
            {
                _enableRightClick = value;
                InvokePropertyChanged("EnableRightClick");
            }
        }
        private bool _enableRightClick;

        /// <summary>
        /// Launch the application when the user logs in.
        /// </summary>
        /// <remarks>Stored in the the registy on a per-user basis</remarks>
        [ScriptIgnore]
        public bool LaunchOnLogin
        {
            get { return _launchOnLogin; }
            set
            {
                _launchOnLogin = value;
                InvokePropertyChanged("LaunchOnLogin");
            }
        }
        private bool _launchOnLogin;

        public event PropertyChangedEventHandler PropertyChanged;
        private void InvokePropertyChanged(string name)
        {
            var e = new PropertyChangedEventArgs(name);
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Constructor sets defaults (S + Shift + Alt)
        /// </summary>
        public ScreenShotConfiguration()
        {
            FullScreenHotKey = new ScreenShotKeyConfiguration() { Key = 'S', Alt = true, Shift = true };
            ActiveWindowHotKey = new ScreenShotKeyConfiguration { Key = 'A', Alt = true, Shift = true };
            EnableRightClick = true;
            LaunchOnLogin = false;
        }

        /// <summary>
        /// Override ToString to give full details of the configuration
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("Full screen hot key is " + FullScreenHotKey.ToString());
            sb.AppendLine("Active window hot key is " + ActiveWindowHotKey.ToString());
            sb.AppendLine("Right click is " + (EnableRightClick ? "enabled" : "disabled"));
            sb.AppendLine("Launch on login is " + (LaunchOnLogin ? "enabled" : "disabled"));

            return sb.ToString();
        }

        /// <summary>
        /// Load the configuration from file.
        /// </summary>
        /// <param name="path">The source configuration file</param>
        /// <returns></returns>
        public static ScreenShotConfiguration Load(string path)
        {
            ScreenShotConfiguration ss;
            try
            {
                //If file exists then load from the file, otherwise use the defaults
                if (File.Exists(path)) {
                    
                    var json = File.ReadAllText(path);
                    var serializer = new JavaScriptSerializer();

                    ss = serializer.Deserialize<ScreenShotConfiguration>(json);
                } else {
                    ss = new ScreenShotConfiguration();
                }

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(String.Format("Could not load configuration from '{0}'. Error was '{1}'", path, ex.Message), ex);
            }

            try
            {
                //If the ScreenShot key exists in the registry, then startup is enabled.
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                ss.LaunchOnLogin = (key.GetValue("ScreenShot", null) != null);
                
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(String.Format("Could not load configuration from registry. Error was '{1}'", path, ex.Message), ex);
            }

            return ss;
        }

        /// <summary>
        /// Save the configuration to file
        /// </summary>
        /// <param name="path">The target configuration file</param>
        public void Save(string path)
        {
            try
            {
                //Serialize the config
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(this);

                //Save to dis
                File.WriteAllText(path,json);
                    
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(String.Format("Could not save configuration to '{0}'. Error was '{1}'", path, ex.Message), ex);                 
            }  

            try
            {
                
                //Update the registry
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (LaunchOnLogin) {                    
                    //Set the value
                    key.SetValue("ScreenShot",String.Format("\"{0}\"",Application.ExecutablePath.ToString()));
                } else {
                    //Delete the value if it exists
                    if (key.GetValue("ScreenShot", null) != null) 
                        key.DeleteValue("ScreenShot");
                }
            } 
            catch (Exception ex)
            {               
                throw new InvalidOperationException(String.Format("Could not save configuration to registry. Error was '{1}'", path, ex.Message), ex); 
            }

        }

    }

    /// <summary>
    /// Configuration class to handle persistence of hot key configuration
    /// </summary>
    /// <remarks>
    /// Includes databinding functionality
    /// </remarks>
    public class ScreenShotKeyConfiguration: INotifyPropertyChanged
    {
        /// <summary>
        /// The base hotkey
        /// </summary>
        public char Key
        {
            get { return _key; }
            set
            {
                _key = value;
                InvokePropertyChanged("Key");
            }
        }
        private char _key;

        /// <summary>
        /// Use the Ctrl key modifier
        /// </summary>
        public bool Ctrl
        {
            get { return _ctrl; }
            set
            {
                _ctrl = value;
                InvokePropertyChanged("Ctrl");
            }
        }
        private bool _ctrl;

        /// <summary>
        /// Use the Alt key modifier
        /// </summary>
        public bool Alt
        {
            get { return _alt; }
            set
            {
                _alt = value;
                InvokePropertyChanged("Alt");
            }
        }
        private bool _alt;

        /// <summary>
        /// Use the Alt key modifier
        /// </summary>
        public bool Shift
        {
            get { return _shift; }
            set
            {
                _shift = value;
                InvokePropertyChanged("Shift");
            }
        }
        private bool _shift;

        /// <summary>
        /// Use the Win key modifier
        /// </summary>
        public bool Win
        {
            get { return _win; }
            set
            {
                _win = value;
                InvokePropertyChanged("Win");
            }
        }
        private bool _win;
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void InvokePropertyChanged(string name)
        {
            var e = new PropertyChangedEventArgs(name);
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Constructor sets defaults (S + Shift + Alt)
        /// </summary>
        public ScreenShotKeyConfiguration()
        {
            Key = 'S';
            Ctrl = false;
            Win = false;
            Shift = true;
            Alt = true;
        }
                  
        /// <summary>
        /// Override ToString to give hotkey description
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ((Ctrl) ? "Ctrl + " : "")
                + ((Shift) ? "Shift + " : "")
                + ((Alt) ? "Alt + " : "")
                + ((Win) ? "Win + " : "")
                + Key;
        }
    }
}
