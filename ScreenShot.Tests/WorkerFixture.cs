using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using NUnit.Framework;
using Moq;

using ScreenShot.Code;

namespace ScreenShot.Tests
{

    [TestFixture, RequiresSTA]
    public class WorkerFixture
    {

        Worker _worker;
        Mock<IKeyboardHook> _hook;
        Mock<ScreenShotConfiguration> _config;

        [SetUp]
        public void Setup ()
        {
            _hook = new Mock<IKeyboardHook>();
            _config = new Mock<ScreenShotConfiguration>();

            //Setup a config
            _config.Object.Key = 'S';
            _config.Object.Alt = true;
            _config.Object.Win = true;
            _config.Object.Shift = false;
            _config.Object.Ctrl = false;
            _config.Object.EnableRightClick = true;

            _worker = new Worker(_config.Object,_hook.Object);
        }
        
        [Test]
        public void CanSetHook()
        {            
            _worker.SetHook();

            _hook.Verify(x => x.ClearHotKeys(),Times.Once());
            _hook.Verify(x => x.RegisterHotKey(_config.Object.Key, _config.Object.Alt, _config.Object.Ctrl, _config.Object.Shift, _config.Object.Win),Times.Once());
        }

        [Test]
        public void CanTakeScreenShot()
        {
            //For now, just verfies that we end up with an image on the clipboard,
            //and that the event gets called
            
            bool eventCalled = false;
            Clipboard.Clear();

            _worker.ScreenShotComplete += (s,e) => eventCalled = true;

            _worker.TakeScreenShot();

            Assert.IsTrue(Clipboard.ContainsImage());
            Assert.IsTrue(eventCalled);
            
        }

        [Test]
        public void CanTakeScreenShotFromHotKey()
        {
            //For now, just verfies that we end up with an image on the clipboard,
            //and that the event gets called

            bool eventCalled = false;
            Clipboard.Clear();

            _worker.ScreenShotComplete += (s, e) => eventCalled = true;

            _hook.Raise(x => x.KeyPressed += null, new KeyPressedEventArgs(ModifierKeys.Alt | ModifierKeys.Win,Keys.S));

            Assert.IsTrue(Clipboard.ContainsImage());
            Assert.IsTrue(eventCalled);

        }
    }
}
