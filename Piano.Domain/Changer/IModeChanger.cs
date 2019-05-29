using System;

namespace Domain
{
    public interface IModeChanger
    {
        event EventHandler ModeChange;
    }
}
