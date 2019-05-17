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

        public override bool Equals(object obj)
        {
            if (!(obj is Melody))
                return false;
            var other = (Melody)obj;
            if (GetHashCode() != other.GetHashCode())
                return false;
            return Notes.Equals(other.Notes);
        }

        public override int GetHashCode()
        {
            return Notes.GetHashCode();
        }
    }
}