using System;
using System.Linq;

namespace Piano
{
    public class Map
    {
        public int NumberInWidth { get; }
        public int NumberInHigh { get; }
        public PianoKey[,] Keys { get; }

        public Map(MapSettings settings, Melody melody,IMapChange mapChange)
        {
            NumberInHigh = settings.Height; 
            NumberInWidth = settings.Width;
            Keys = new PianoKey[NumberInHigh, NumberInWidth];
            for (var i = 0; i < NumberInHigh; i++)
                for (var j = 0; j < NumberInWidth; j++)
                {
                    Keys[i, j] = new PianoKey();
                }
            var index = 0;
            for (var i = 0; i < NumberInHigh; i++)
            {
                var note = melody.Notes.ElementAt(index);
                index = index + 1 < melody.Notes.Count() ? index + 1 : 0;
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
    }
}
