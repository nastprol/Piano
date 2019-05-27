using System.Drawing;

namespace Piano
{
    public class PianoKey
    {
        public PianoKey(Note note)
        {
            Note = note;
            IsNote = true;
        }

        public PianoKey() => IsNote = false;
        

        public void Press() => IsNote = IsNote = false;

        public bool IsNote { get; private set; }
        public Note Note { get; }
    }
}