using System.Collections.Generic;
using System.Linq;

namespace Piano
{
    public class Melody
    {
        public Melody(IEnumerable<Note> notes)
        {
            this.notes = notes;
            Count = notes.Count();
        }

        private IEnumerable<Note> notes;
        public int Count { get; private set; } 

        public override bool Equals(object obj)
        {
            if (!(obj is Melody))
                return false;
            var other = (Melody) obj;
            return GetHashCode() == other.GetHashCode() && notes.Equals(other.notes);
        }

        public List<Note> ToList() => notes.ToList();

        public override int GetHashCode()
        {
            return notes.GetHashCode();
        }
    }
}