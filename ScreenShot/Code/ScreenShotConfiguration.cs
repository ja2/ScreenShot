using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.ComponentModel;

using Newtonsoft.Json;

namespace ScreenShot
{
    /// <summary>
    /// Configuration class to handle persistence of settings
    /// </summary>
    /// <remarks>
    /// Includes databinding functionality
    /// </remarks>
    [Serializable()] 
    public class ScreenShotConfiguration: INotifyPropertyChanged
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
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void InvokePropertyChanged(string name)
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
            Key = 'S';
            Ctrl = false;
            Win = false;
            Shift = true;
            Alt = true;
            EnableRightClick = true;
        }

        public override string ToString()
        {
            return "Hot key is " 
                + ((Ctrl) ? "Ctrl + " : "")
                + ((Shift) ? "Shift + " : "")
                + ((Alt) ? "Alt + " : "")
                + ((Win) ? "Win + " : "")
                + Key
                + ((EnableRightClick) ? " or Right Click": "");
        }

        /// <summary>
        /// Load the configuration from file.
        /// </summary>
        /// <param name="path">The source configuration file</param>
        /// <returns></returns>
        public static ScreenShotConfiguration LoadFrom(string path)
        {
            try
            {
                //If file exists then load from the file, otherwise use the defaults
                if (File.Exists(path)) {
                    var json = File.ReadAllText(path);
                    return JsonConvert.DeserializeObject<ScreenShotConfiguration>(json);
                } else {
                    return new ScreenShotConfiguration();
                }

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(String.Format("Could not load configuration from '{0}'. Error was '{1}'", path, ex.Message), ex);
            }            
        }

        /// <summary>
        /// Save the configuration to file
        /// </summary>
        /// <param name="path">The target configuration file</param>
        public void SaveTo(string path)
        {
            try
            {
                //Serialize the config
                var json = JsonConvert.SerializeObject(this);

                //Save to dis
                File.WriteAllText(path,json);
                    
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(String.Format("Could not save configuration to '{0}'. Error was '{1}'", path, ex.Message), ex);                 
            }  
        }

    }
}
