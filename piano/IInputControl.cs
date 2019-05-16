using System;

namespace Piano
{
    public interface IInputControl
    {
        int InputValue { get; }
        void MakeInput(object sender, EventArgs e);
    }
}
