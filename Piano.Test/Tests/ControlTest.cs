using NUnit.Framework;
using Moq;
using System.Windows.Forms;
using Domain.Infrastructure;
using App;
using Domain;

namespace Piano.Test
{
    [TestFixture]
    public class ControlTest
    {
        private int Input = -1;
        private MouseInputControl mouseControl;
        private KeyBoardInputControl keyControl;

        public void TestInput(object sender, InputEventArgs e)
        {
            Input = e.KeyNumber;
        }

        [SetUp]
        public void SetUp()
        {
            var mouseInput = new Mock<IMouseInput>();
            var visual = new VisualizationSettings(new KeySettings());
            mouseControl = new MouseInputControl(visual, mouseInput.Object);
            var keyInput = new Mock<IKeyInput>();
            keyControl = new KeyBoardInputControl(new KeyBoardSettings(), keyInput.Object);
            keyControl.Input += TestInput;
            mouseControl.Input += TestInput;
        }

        [TestCase(1, 5, 5, 0, -1)]
        [TestCase(1, 0, 300, 1, 0)]
        [TestCase(1, 0, 0, 0, -1)]
        [TestCase(1, 5, 5, 0, -1, MouseButtons.Right)]
        [TestCase(1, 0, 300, 1, -1, MouseButtons.Right)]
        [TestCase(1, 0, 0, 0, -1, MouseButtons.Right)]
        public void ClickLocation(int clicks, int x, int y, int delta, int keyNumber, MouseButtons button=MouseButtons.Left)
        {
            var args = new MouseEventArgs(button, clicks, x, y, delta);
            mouseControl.MakeInput(null, args);
            Assert.AreEqual(Input, keyNumber);
            Input = -1;
        }

        [TestCase(Keys.Q, 0)]
        [TestCase(Keys.A, -1)]
        public void PressKey(Keys key, int keyNumber)
        {
            var args = new KeyEventArgs(key);
            keyControl.MakeInput(null, args);
            Assert.AreEqual(Input, keyNumber);
            Input = -1;
        }
    }
}