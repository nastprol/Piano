using System;

namespace Domain
{
    public interface ILocatorChanger
    {
        event EventHandler LocatorChange;
    }
}
