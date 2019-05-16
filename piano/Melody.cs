using System.Collections.Generic;

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