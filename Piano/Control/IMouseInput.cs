using System;
using System.Windows.Forms;

namespace Piano.Control
{
    public interface IMouseInput
    {
        event EventHandler Click;        
    }
}