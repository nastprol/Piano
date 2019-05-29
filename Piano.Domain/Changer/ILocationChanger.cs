using System;

namespace Domain
{
    public interface ILocationChanger
    {
        event EventHandler LocationChange;
    }
}
