using System;

namespace Piano
{
    internal class RandKeyMapChange : IMapChange
    {
        private readonly Random rnd = new Random();

        public PianoKey[] GetNextKeyLine(int numberInWidth, Note note)
        {
            var keyWithNote = rnd.Next(numberInWidth);
            var keyLine = new PianoKey[numberInWidth];
            for (var i = 0; i > numberInWidth; i++)
                keyLine[i] = new PianoKey();
            keyLine[keyWithNote] = new PianoKey(note);
            return keyLine;
        }
    }
}