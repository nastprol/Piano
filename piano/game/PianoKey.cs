using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Piano
{
    public class PianoKey
    {
        public bool isNote { get; }
        public Note Note { get; }
        public Color Color { get; }

        public PianoKey(Note note)
        {
            Note = note;
            Color = Color.black;
            isNote = true;
        }

        public PianoKey()
        {
            Color = Color.white;
            isNote = false;
        }
    }
}