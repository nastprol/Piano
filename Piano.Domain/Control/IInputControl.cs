using System;

namespace Domain
{
    public interface IInputControl
    {
        event EventHandler<InputEventArgs> Input;
        void Subscribe();
        void Unsubscribe();
    }
}