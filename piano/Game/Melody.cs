using System.Collections.Generic;

namespace Piano
{
    public class Melody
    {
        public Melody(IEnumerable<Note> notes)
        {
            Notes = notes;
        }

        public IEnumerable<Note> Notes { get; } // неверное стоит сделать приватным и сделать этот класс более богатым

        public override bool Equals(object obj)
        {
            if (!(obj is Melody))
                return false;
            var other = (Melody) obj;
            return GetHashCode() == other.GetHashCode() && Notes.Equals(other.Notes);
        }

        public override int GetHashCode()
        {
            return Notes.GetHashCode();
        }
    }
}