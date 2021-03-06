﻿using System.Linq;

namespace Domain.Infrastructure
{
    public class Melody
    {
        private readonly Note[] notes;

        public Melody(Note[] notes)
        {
            this.notes = notes;
            Count = notes.Length;
        }

        public int Count { get; }

        public Note this[int index] => notes[index];

        public override bool Equals(object obj)
        {
            if (!(obj is Melody))
                return false;
            var other = (Melody) obj;
            return GetHashCode() == other.GetHashCode() && Enumerable.SequenceEqual(notes, other.notes);
        }

        public override int GetHashCode()
        {
            var hash = 0;
            var prime = 2017;
            foreach (var n in notes) hash += (hash * (int) n) ^ prime;
            return hash;
        }
    }
}