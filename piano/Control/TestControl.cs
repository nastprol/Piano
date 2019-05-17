using NUnit.Framework;
using Piano;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class TestControl
    {
        [Test]
        public void PressWrongKey()
        {
            IInputControl control = new KeyBoardInputControl(new KeyBoardSettings());
            var args = new KeyEventArgs(Keys.A);
            Assert.IsFalse(control.MakeInput(args));
        }

        [Test]
        public void PressRightKey()
        {
            IInputControl control = new KeyBoardInputControl(new KeyBoardSettings());
            var args = new KeyEventArgs(Keys.Q);
            Assert.IsTrue(control.MakeInput(args));
            Assert.AreEqual(control.InputValue, 0);
        }

        [Test]
        public void ClickWrongLocation()
        {
            IInputControl control = new MouseInputControl(new MouseSettings());
            var args = new MouseEventArgs(MouseButtons.Left, 1, 5, 5, 0);
            Assert.IsFalse(control.MakeInput(args));
        }

        [Test]
        public void ClickRightLocation()
        {
            IInputControl control = new MouseInputControl(new MouseSettings());
            var args = new MouseEventArgs(MouseButtons.Left, 1, 40, 40, 0);
            Assert.AreEqual(control.InputValue, 0);
        }
    }
}