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
            return GetHashCode() == other.GetHashCode() && notes.SequenceEqual(other.notes);
        }

        public List<Note> ToList() => notes.ToList();

        public override int GetHashCode()
        {
            var hash = 0;
            var prime = 2017;
            foreach (var n in notes)
            {
                hash += (hash * (int)n) ^ prime;
            }
            return hash;
        }
    }
}