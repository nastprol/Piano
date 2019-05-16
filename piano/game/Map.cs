using System;

namespace Piano
{
    public class Map
    {
        public int NumberInWidth { get; }
        public int NumberInHigh { get; }
        public PianoKey[,] Keys { get; }

        public Map(int width, int high)
        {
            NumberInHigh = high;
            NumberInWidth = width;
            Keys = new PianoKey[high, width];
        }

        public PianoKey this[int i, int j]
        {
            get
            {
                return Keys[i, j];
            }
            set
            {
                Keys[i,j] = value;
            }
        }

        public void SetNextKeyLine(PianoKey[] keyLine)
        {
            if (keyLine.Length != NumberInWidth)
                throw new Exception();
            for(var i = 0; i< NumberInHigh-1; i++)
                for(var j = 0; j< NumberInWidth; j++)
                {
                    Keys[i, j] = Keys[i + 1,j];
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
