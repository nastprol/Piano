using System.Windows.Forms;

namespace Domain
{
    public interface IKeyInput
    {
        event KeyEventHandler KeyDown;
    }
}