namespace Piano
{
    public class Melody
    {
        public Melody(Note[] notes)
        {
            this.notes = notes;
            Count = notes.Length;
        }

        private readonly Note[] notes;
        public int Count { get; }

        public Note this[int index] => notes[index];

        public override bool Equals(object obj)
        {
            if (!(obj is Melody))
                return false;
            var other = (Melody) obj;
            return GetHashCode() == other.GetHashCode() && notes.Equals(other.notes);
        }

        public override int GetHashCode()
        {
            return notes.GetHashCode();
        }
    }
}