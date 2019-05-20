using System.Collections.Generic;

namespace Piano.Control
{
    public interface ISettings<TIn>
    {
        IReadOnlyDictionary<TIn, int> ControlTools { get; }
    }
}