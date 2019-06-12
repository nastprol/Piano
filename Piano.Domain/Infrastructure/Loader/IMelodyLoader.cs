using System.Collections.Generic;

namespace Domain.Infrastructure
{
    public interface IMelodyLoader
    {
        Melody Load();

        IEnumerable<Melody> Melodies { get; }
    }
}