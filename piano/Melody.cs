using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    public class Melody
    {
        private List<Note> notes;
        public IEnumerable<Note> Notes => notes;

        public Melody(IEnumerable<Note> notes)
        {
            this.notes = notes.ToList();
        }
    }
}
