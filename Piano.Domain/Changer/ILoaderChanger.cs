using System;

namespace Domain
{
    public interface ILoaderChanger
    {
        event EventHandler LoaderChange;
    }
}
