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

        public void Press()
        {
            Color = Color.White;
            IsNote = false;
        }

        public bool IsNote { get; private set; }
        public Note Note { get; }
        public Color Color { get; private set; }  // наверное стоит color вообще отсюда удалить тк сейчас он дублирует isNote
    }
}