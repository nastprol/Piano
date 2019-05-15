
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