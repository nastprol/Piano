using System;

namespace Domain
{
    public interface IInputControl
    {
        event EventHandler<InputEventArgs> Input;
    }
}