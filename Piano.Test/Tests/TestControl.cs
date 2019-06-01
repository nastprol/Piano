using NUnit.Framework;
using Domain;
using Moq;
using System.Windows.Forms;

namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class TestControl
    {
        private int Input;

        public void TestInput(object sender, InputEventArgs e)
        {
            Input = e.KeyNumber;
        }

        [Test]
        public void ClickRightLocation()
        {
            Mock<IMouseInput> mouseInput = new Mock<IMouseInput>();
            var visual = new VisualizationSettings(new KeySettings());
            var control = new MouseInputControl(visual, mouseInput.Object);
            Input = -1;
            control.Input += TestInput;
            control.MakeInput(null, new MouseEventArgs(MouseButtons.Left, 1, 0, 300, 1));
            Assert.AreEqual(Input, 0);
        }

        [Test]
        public void ClickWrongLocation()
        {
            Mock<IMouseInput> mouseInput = new Mock<IMouseInput>();
            var visual = new VisualizationSettings(new KeySettings());
            var control = new MouseInputControl(visual, mouseInput.Object);
            Input = -1;
            control.Input += TestInput;
            control.MakeInput(null, new MouseEventArgs(MouseButtons.Left, 1, 5, 5, 0));
            Assert.AreEqual(Input, -1);
        }

        [Test]
        public void PressRightKey()
        {
            Mock<IKeyInput> keyInput = new Mock<IKeyInput>();
            var control = new KeyBoardInputControl(new KeyBoardSettings(), keyInput.Object);
            control.Input += TestInput;
            var args = new KeyEventArgs(Keys.Q);
            control.MakeInput(null, args);
            Assert.AreEqual(Input, 0);
        }

        [Test]
        public void PressWrongKey()
        {
            Mock<IKeyInput> keyInput = new Mock<IKeyInput>();
            var control = new KeyBoardInputControl(new KeyBoardSettings(), keyInput.Object);
            control.Input += TestInput;
            Input = -1;
            var args = new KeyEventArgs(Keys.A);
            control.MakeInput(null, args);
            Assert.AreEqual(Input, -1);
        }
    }
}