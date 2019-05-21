using System.Drawing;

namespace Piano
{
    public class PianoKey
    {
        public PianoKey(Note note)
        {
            Note = note;
            Color = Color.Black;
            IsNote = true;
        }

        public PianoKey()
        {
            Color = Color.White;
            IsNote = false;
        }

        public bool IsNote { get; }
        public Note Note { get; }
        public Color Color { get; }  // наверное стоит color вообще отсюда удалить тк сейчас он дублирует isNote
    }
}