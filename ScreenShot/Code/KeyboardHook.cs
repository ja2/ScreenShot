using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ScreenShot.Code
{
    public interface IKeyboardHook
    {
        void RegisterHotKey(ModifierKeys modifier, Keys key);
        void RegisterHotKey(char key, bool alt = false, bool ctrl = false, bool shift = false, bool win = false);
        void ClearHotKeys();
        event EventHandler<KeyPressedEventArgs> KeyPressed;
    }

    public sealed class KeyboardHook : IDisposable, IKeyboardHook
    {         

        private Window _window;
        private User32API _user32Api;
        private int _currentId;

        public KeyboardHook()
            :this(null,null)
        {}

        public KeyboardHook(Window window, User32API user32Api)
        {

            _window = window ?? new Window();
            _user32Api = user32Api ?? new User32API();

            // register the event of the inner native window.
            _window.KeyPressed += (s,args) => 
                {
                    if (KeyPressed != null)
                        KeyPressed(this, args);
                };
        }

        /// <summary>
        /// Registers a hot key in the system.
        /// </summary>
        /// <param name="modifier">The modifiers that are associated with the hot key.</param>
        /// <param name="key">The key itself that is associated with the hot key.</param>
        public void RegisterHotKey(ModifierKeys modifier, Keys key)
        {
            // increment the counter.
            _currentId = _currentId + 1;

            // register the hot key.
            if (!_user32Api.RegisterHotKey(_window.Handle, _currentId, (uint)modifier, (uint)key))
                throw new InvalidOperationException("Couldn’t register the hot key.");
        }

        /// <summary>
        /// Registers a hot key in the system.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="alt"></param>
        /// <param name="ctrl"></param>
        /// <param name="shift"></param>
        /// <param name="win"></param>
        public void RegisterHotKey(char key, bool alt = false, bool ctrl = false, bool shift = false, bool win = false)
        {
            //Get the keycode
            var keyCode = (Keys)Enum.Parse(typeof(Keys), key.ToString());

            //Get the modifier value
            ModifierKeys modifier = ((alt) ? ModifierKeys.Alt : 0)
                                    | ((ctrl) ? ModifierKeys.Control : 0)
                                    | ((shift) ? ModifierKeys.Shift: 0)
                                    | ((win) ? ModifierKeys.Win: 0);

            //Register
            RegisterHotKey(modifier, keyCode);
        }

        /// <summary>
        /// Clears all hot keys registered
        /// </summary>
        public void ClearHotKeys()
        {
            // unregister all the registered hot keys.
            for (int i = _currentId; i > 0; i--)
            {
                _user32Api.UnregisterHotKey(_window.Handle, i);
            }
        }

        /// <summary>
        /// A hot key has been pressed.
        /// </summary>
        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        #region IDisposable Members

        public void Dispose()
        {
            //Clear hooked keys
            ClearHotKeys();

            // dispose the inner native window.
            _window.Dispose();
        }

        #endregion
    }

    /// <summary>
    /// Event Args for the event that is fired after the hot key has been pressed.
    /// </summary>
    public class KeyPressedEventArgs : EventArgs
    {
        private ModifierKeys _modifier;
        private Keys _key;

        public KeyPressedEventArgs(ModifierKeys modifier, Keys key)
        {
            _modifier = modifier;
            _key = key;
        }

        public ModifierKeys Modifier
        {
            get { return _modifier; }
        }

        public Keys Key
        {
            get { return _key; }
        }
    }

    /// <summary>
    /// The enumeration of possible modifiers.
    /// </summary>
    [Flags]
    public enum ModifierKeys : uint
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }
}
