using System.Windows.Forms;

namespace Piano.Control
{
    public interface IKeyInput
    {
        event KeyEventHandler KeyDown;
    }
}