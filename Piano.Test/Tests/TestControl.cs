using NUnit.Framework;
using Domain;
using Moq;
using System.Windows.Forms;

namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class TestControl
    {

        [Test]
        public void ClickRightLocation()
        {
            Mock<IMouseInput> mouseInput = new Mock<IMouseInput>();
            var visual = new VisualizationSettings(new KeySettings());
            var control = new MouseInputControl(visual, mouseInput.Object);
            Assert.AreEqual(control.MakeInput(new MouseEventArgs(MouseButtons.Right,1,1,1,1)), null);
        }

        [Test]
        public void ClickWrongLocation()
        {
            Mock<IMouseInput> mouseInput = new Mock<IMouseInput>();
            var visual = new VisualizationSettings(new KeySettings());
            var control = new MouseInputControl(visual, mouseInput.Object);
            Assert.AreEqual(control.MakeInput(new MouseEventArgs(MouseButtons.Left, 1, 5, 5, 0)), null);
        }

        [Test]
        public void PressRightKey()
        {
            Mock<IKeyInput> keyInput = new Mock<IKeyInput>();
            var control = new KeyBoardInputControl(new KeyBoardSettings(), keyInput.Object);
            var args = new KeyEventArgs(Keys.Q);
            Assert.AreEqual(control.MakeInput(args), 0);
        }

        [Test]
        public void PressWrongKey()
        {
            Mock<IKeyInput> keyInput = new Mock<IKeyInput>();
            var control = new KeyBoardInputControl(new KeyBoardSettings(), keyInput.Object);
            var args = new KeyEventArgs(Keys.A);
            Assert.AreEqual(control.MakeInput(args), null);
        }
    }
}