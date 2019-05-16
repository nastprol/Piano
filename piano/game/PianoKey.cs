using System.Drawing;

namespace Piano
{
    public class PianoKey
    {
        public PianoKey(Note note)
        {
            Note = note;
            Color = Color.Black;
            isNote = true;
        }

        public PianoKey()
        {
            Color = Color.White;
            isNote = false;
        }

        public bool isNote { get; }
        public Note Note { get; }
        public Color Color { get; }
    }
}