using System;

namespace Domain.Control
{
    public interface IMouseInput
    {
        event EventHandler Click;
    }
}