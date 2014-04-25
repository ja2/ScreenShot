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

        /// <summary>
        /// Hook to control full screen hotkey
        /// </summary>
        private IKeyboardHook _fshook;

        /// <summary>
        /// Hook to control active window hotkey
        /// </summary>
        private IKeyboardHook _awhook;

        /// <summary>
        /// Access point for the User32 API commands.
        /// </summary>
        private User32API _user32Api;

        /// <summary>
        /// The configuration object that controls when screens are grabbed
        /// </summary>
        public ScreenShotConfiguration Config;

        /// <summary>
        /// Constructor sets up the hookand registers the configuration
        /// </summary>
        /// <param name="config"></param>
        public Worker(ScreenShotConfiguration config)
            :this(config,null,null,null)
        {}

        /// <summary>
        /// Constructor sets up the hookand registers the configuration
        /// </summary>
        public Worker(ScreenShotConfiguration config, IKeyboardHook fshook, IKeyboardHook awhook, User32API user32Api)
        {
            _fshook = fshook ?? new KeyboardHook();
            _fshook.KeyPressed += (s,e) => TakeScreenShot(fullScreen:true);

            _awhook = awhook ?? new KeyboardHook();
            _awhook.KeyPressed += (s,e) => TakeScreenShot(fullScreen:false);

            _user32Api = user32Api ?? new User32API();
            Config = config;     
        }
        

        /// <summary>
        /// Resets the hooked key combination
        /// </summary>
        public void SetHook()
        {

            //Clear existing hooks
            _fshook.ClearHotKeys();
            _awhook.ClearHotKeys();
                       
            //Switch the hook listener key setting
            _fshook.RegisterHotKey(Config.FullScreenHotKey.Key, 
                Config.FullScreenHotKey.Alt, 
                Config.FullScreenHotKey.Ctrl,
                Config.FullScreenHotKey.Shift,
                Config.FullScreenHotKey.Win);

            //Switch the hook listener key setting
            _awhook.RegisterHotKey(Config.ActiveWindowHotKey.Key,
                Config.ActiveWindowHotKey.Alt,
                Config.ActiveWindowHotKey.Ctrl,
                Config.ActiveWindowHotKey.Shift,
                Config.ActiveWindowHotKey.Win);
            
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
        public void TakeScreenShot(bool fullScreen)
        {

            Rectangle area;

            if (fullScreen)
            {
                //Get which screen to screenshot
                var screen = Screen.FromPoint(Control.MousePosition);

                //Use the full screen bounds
                area = screen.Bounds;
            }
            else
            {
                //Get the area of the active window
                area = _user32Api.GetActiveWindowArea();
            }

            
            //Set the size of the image
            Bitmap bmp = new Bitmap(area.Width, area.Height);

            //Create a graphics
            Graphics g = Graphics.FromImage(bmp as Image);

            //Take the screenshot
            g.CopyFromScreen(area.Left, area.Top, 0, 0, area.Size);

            //Write to clipboard
            Clipboard.SetImage(bmp);
    
            //Notify the UI
            OnScreenShotComplete(EventArgs.Empty);

        }


    }
}
