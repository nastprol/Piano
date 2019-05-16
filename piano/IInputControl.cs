using System;
using System.Windows.Forms;

namespace Piano
{
    public interface IInputControl
    {
        int InputValue { get; }
        bool MakeInput(EventArgs e);
        void Subscribe(Form form, Сontroller сontroller);
    }
}
