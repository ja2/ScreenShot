using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ScreenShot.Code
{
    /// <summary>
    /// Declares windows interop entrypoints
    /// </summary>
    public class User32API
    {
        private class API
        {

            /// <summary>
            /// Registers a hot key with Windows.
            /// </summary>
            [DllImport("user32.dll")]
            public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
 
            /// <summary>
            /// Unregisters the hot key with Windows.
            /// </summary>        
            [DllImport("user32.dll")]
            public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        }

        /// <summary>
        /// Registers a hot key with Windows.
        /// </summary>
        public bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk)
        {
            return API.RegisterHotKey(hWnd, id, fsModifiers, vk);
        }

        /// <summary>
        /// Unregisters the hot key with Windows.
        /// </summary>  
        public bool UnregisterHotKey(IntPtr hWnd, int id)
        {
            return API.UnregisterHotKey(hWnd, id);
        }


    }
}
