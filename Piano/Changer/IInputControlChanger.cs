using System;

namespace Piano
{
    public interface IInputControlChanger
    {
        event EventHandler InputTypeChange;
    }
}
