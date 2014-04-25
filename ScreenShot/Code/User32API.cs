using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace ScreenShot.Code
{
    /// <summary>
    /// Declares windows interop entrypoints
    /// </summary>
    public class User32API
    {
        

        private class API
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int Left;        // x position of upper-left corner  
                public int Top;         // y position of upper-left corner  
                public int Right;       // x position of lower-right corner  
                public int Bottom;      // y position of lower-right corner  
            }

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

            /// <summary>
            /// Gets a handle for the currently active window.
            /// </summary>        
            [DllImport("user32.dll")]
            public static extern IntPtr GetForegroundWindow();

            /// <summary>
            /// Gets the bounds of a window
            /// </summary>
            /// <returns></returns>
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect); 
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

        /// <summary>
        /// Returns a rectangle describing the active window.
        /// </summary>
        /// <returns></returns>
        public Rectangle GetActiveWindowArea()
        {
            //Get a pointer to the active window
            IntPtr handle = API.GetForegroundWindow();

            //Get the window rectangle
            API.RECT rect;
            API.GetWindowRect(handle, out rect);

            //Return as a Rectangle
            return new Rectangle(
                rect.Left,
                rect.Top,
                rect.Right - rect.Left,
                rect.Bottom - rect.Top
                );
            
        }

    }
}
