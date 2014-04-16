using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;  
using System.Drawing.Imaging; 

namespace ScreenShot.Code
{
    /// <summary>
    /// Handles setting up the Keyboard hook, then takes the screen shot.
    /// </summary>
    public class Worker
    {

        public delegate void ScreenShotCompleteHandler(object sender, EventArgs e);
        public event ScreenShotCompleteHandler ScreenShotComplete;

        private IKeyboardHook _hook;

        /// <summary>
        /// The configuration object that controls when screens are grabbed
        /// </summary>
        public ScreenShotConfiguration Config;

        /// <summary>
        /// Constructor sets up the hookand registers the configuration
        /// </summary>
        /// <param name="config"></param>
        public Worker(ScreenShotConfiguration config)
            :this(config,null)
        {}

        /// <summary>
        /// Constructor sets up the hookand registers the configuration
        /// </summary>
        public Worker(ScreenShotConfiguration config, IKeyboardHook hook)
        {
            _hook = hook ?? new KeyboardHook();
            _hook.KeyPressed += _hook_KeyPressed;
            Config = config;     
        }

        /// <summary>
        /// Handler for the hook KeyUp event. Checks the modifiers then calls the screen shot.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            //Call the screenshot
            TakeScreenShot();
        }

        /// <summary>
        /// Resets the hooked key combination
        /// </summary>
        public void SetHook()
        {

            //Clear existing hooks
            _hook.ClearHotKeys();
                       
            //Switch the hook listener key setting
            _hook.RegisterHotKey(Config.Key, Config.Alt, Config.Ctrl, Config.Shift, Config.Win);
            
        }


        /// <summary>
        /// Invoke any registered GrabCompleteHandler
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnScreenShotComplete(EventArgs e)
        {
            if (ScreenShotComplete != null)
                ScreenShotComplete(this, e);
        }
        
        /// <summary>
        /// Take the screen print, then raise an event back to the UI
        /// </summary>
        public void TakeScreenShot()
        {

            //Get which screen to screenshot
            var screen = Screen.FromPoint(Control.MousePosition);

            //Set the size of the image
            Bitmap bmp = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);

            //Create a graphics
            Graphics g = Graphics.FromImage(bmp as Image);

            //Take the screens
            g.CopyFromScreen(screen.Bounds.Left, screen.Bounds.Top, 0, 0, bmp.Size);

            //Write to clipboard
            Clipboard.SetImage(bmp);
    
            //Notify the UI
            OnScreenShotComplete(EventArgs.Empty);

        }


    }
}
