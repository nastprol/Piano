using System;
using System.Windows.Forms;

namespace Piano
{
    public interface IInputControl
    {
        int? MakeInput(EventArgs e); 
        void Subscribe(Controller controller); 
    }
}