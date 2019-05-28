using System;

namespace Domain
{
    public interface IInputControlChanger
    {
        event EventHandler InputTypeChange;
    }
}
