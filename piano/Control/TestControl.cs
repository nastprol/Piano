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
            var points1 = new Tuple<Point, Point>(new Point(0, 0), new Point(2, 2));
            var points2 = new Tuple<Point, Point>(new Point(3, 0), new Point(5, 2));
            var locations = new Dictionary<Tuple<Point, Point>, int> { { points1, 0 }, { points2, 1 } };
            IInputControl control = new MouseInputControl(locations);
            var args = new MouseEventArgs(MouseButtons.Left, 1, 5, 5, 0);
            Assert.IsFalse(control.MakeInput(args));
        }

        [Test]
        public void ClickRightLocation()
        {
            var points1 = new Tuple<Point, Point>(new Point(0, 0), new Point(2, 2));
            var points2 = new Tuple<Point, Point>(new Point(3, 0), new Point(5, 2));
            var locations = new Dictionary<Tuple<Point, Point>, int> { { points1, 0 }, { points2, 1 } };
            IInputControl control = new MouseInputControl(locations);
            var args = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0);
            Assert.IsTrue(control.MakeInput(args));
            Assert.AreEqual(control.InputValue, 0);
        }
    }
}