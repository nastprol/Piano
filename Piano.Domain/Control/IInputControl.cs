using System;
using Domain.Infrastructure;

namespace Domain
{
    public interface IInputControl
    {
        event EventHandler<InputEventArgs> Input;
        void Subscribe();
        void Unsubscribe();
    }
}