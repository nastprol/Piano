
namespace Piano
{
    public class PianoKey
    {
        public bool isNote { get; }
        public Note Note { get; }
        public System.Drawing.Color Color { get; }

        public PianoKey(Note note)
        {
            Note = note;
            Color = System.Drawing.Color.Black;
            isNote = true;
        }

        public PianoKey()
        {
            Color = System.Drawing.Color.White;
            isNote = false;
        }
    }
}