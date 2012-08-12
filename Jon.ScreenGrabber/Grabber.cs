using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;  
using System.Drawing.Imaging; 

namespace Jon.ScreenGrabber
{
    /// <summary>
    /// Handles setting up the Keyboard hook, then takes the screen grab.
    /// </summary>
    public class Grabber
    {

        public delegate void GrabCompleteHandler(object sender, EventArgs e);       
        public event GrabCompleteHandler GrabComplete;

        private globalKeyboardHook _hook;

        /// <summary>
        /// The configuration object that controls when screens are grabbed. Updates the hook with changes to the keys.
        /// </summary>
        public ScreenGrabberConfiguration Config
        {
            get
            {
                return _config;
            }
            set
            {
                _config = value;

                //Switch the hook listener key setting
                _hook.HookedKeys.Clear();
                var key = (Keys)Enum.Parse(typeof(Keys), _config.Key);
                _hook.HookedKeys.Add(key);
            }
        }
        private ScreenGrabberConfiguration _config;         

        /// <summary>
        /// Constructor sets up the hookand registers the configuration
        /// </summary>
        /// <param name="config"></param>
        public Grabber(ScreenGrabberConfiguration config) {
            _hook = new globalKeyboardHook();            
            _hook.KeyUp += new KeyEventHandler(_hook_KeyUp);
            Config = config;                        
        }

        /// <summary>
        /// Handler for the hook KeyUp event. Checks the modifiers then calls the screen grab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _hook_KeyUp(object sender, KeyEventArgs e)
        {
            //Check the modifiers match up
            if (e.Alt != Config.Alt || e.Shift != Config.Shift || e.Control != Config.Ctrl) return;

            //Call the grab
            GrabScreen();
        }


        /// <summary>
        /// Invoke any registered GrabCompleteHandler
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnGrabComplete(EventArgs e)
        {
            if (GrabComplete != null)
                GrabComplete(this, e);
        }

        //The action that takes the screen print, then raises an event back to the UI

        /// <summary>
        /// Take the screen print, then raise an event back to the UI
        /// </summary>
        public void GrabScreen()
        {

            //Set the size of the image
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //Create a graphics
            Graphics g = Graphics.FromImage(bmp as Image);

            //Take the screen
            g.CopyFromScreen(0, 0, 0, 0, bmp.Size);

            //Write to clipboard
            Clipboard.SetImage(bmp);
    
            //Notify the UI
            OnGrabComplete(EventArgs.Empty);

        }


    }
}
