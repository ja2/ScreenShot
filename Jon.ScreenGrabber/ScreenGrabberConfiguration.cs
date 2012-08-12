using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Jon.ScreenGrabber
{
    [Serializable()] 
    public class ScreenGrabberConfiguration
    {
        public string Key { get; set; }
        public bool Ctrl { get; set; }
        public bool Shift { get; set; }
        public bool Alt { get; set; }
        public bool EnableRightClick { get; set; }

        //Set sensible defaults
        public ScreenGrabberConfiguration()
        {
            Key = "G";
            Ctrl = true;
            Shift = false;
            Alt = true;
            EnableRightClick = true;
        }
    }
}
