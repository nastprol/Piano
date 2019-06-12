using System;
using Domain.Infrastructure;

namespace Domain
{
    public interface IInputControl
    {
        event EventHandler<InputEventArgs> Input;
    }
}