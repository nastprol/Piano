using System;
using System.Linq;

namespace Piano
{
    public class Map
    {
        public int NumberInWidth { get; }
        public int NumberInHigh { get; }
        public PianoKey[,] Keys { get; }
        public Melody Melody { get; }
        private int index;
        private int melodyLength;

        private IMapChange mapChange;

        public Map(MapSettings settings, Melody melody,IMapChange mapChange)
        {
            NumberInHigh = settings.Height; 
            NumberInWidth = settings.Width;
            this.index = NumberInHigh;
            this.mapChange = mapChange;
            melodyLength = melody.Notes.Count();
            
            Keys = new PianoKey[NumberInHigh, NumberInWidth];
            Melody = melody;
            for (var i = 0; i < NumberInHigh; i++)
                for (var j = 0; j < NumberInWidth; j++)
                {
                    Keys[i, j] = new PianoKey();
                }
            var index = 0;
            for (var i = 0; i < NumberInHigh; i++)
            {
                var note = Melody.Notes.ElementAt(index);
                index = index + 1 < Melody.Notes.Count() ? index + 1 : 0;
                SetNextKeyLine(mapChange.GetNextKeyLine(NumberInWidth, note));
            }
        }

        public PianoKey this[int i, int j]
        {
            get
            {
                return Keys[i, j];
            }
            set
            {
                Keys[i, j] = value;
            }
        }

        public void SetNextKeyLine(PianoKey[] keyLine)
        {
            if (keyLine.Length != NumberInWidth)
                throw new Exception();
            for (var i = 0; i < NumberInHigh - 1; i++)
                for (var j = 0; j < NumberInWidth; j++)
                {
                    Keys[i, j] = Keys[i + 1, j];
                }
            for (var j = 0; j < NumberInWidth; j++)
                Keys[NumberInHigh - 1, j] = keyLine[j];
        }

        public PianoKey[] GetFirstLine()
        {
            var lastLine = new PianoKey[NumberInWidth];
            for (var j = 0; j < NumberInWidth; j++)
                lastLine[j] = Keys[0, j];
            return lastLine;
        }

        public void MapUpdate()
        {
            index = index + 1 < melodyLength ? index + 1 : 0;
            var nextNote = Melody.Notes.ElementAt(index);
            SetNextKeyLine(mapChange.GetNextKeyLine(NumberInWidth, nextNote));
        }
    }
}
