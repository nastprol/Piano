using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    public interface IMapChange
    {
        PianoKey[] GetNextKeyLine(int numberInWidth, Note note);
    }
}
