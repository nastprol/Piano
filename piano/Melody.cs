using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    public class Melody
    {
        public readonly IEnumerable<Note> Notes;

        public Melody(IEnumerable<Note> notes)
        {
            Notes = notes;
        }
    }
}
