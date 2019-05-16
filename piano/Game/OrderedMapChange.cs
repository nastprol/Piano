namespace Piano
{
    internal class OrderedMapChange : IMapChange
    {
        private readonly int[] combination =
            {0, 1, 1, 2, 3, 3, 4, 5, 6, 7, 8, 8, 5, 4, 6, 6, 7, 2, 3, 5, 3, 5, 3, 2, 2, 1, 0, 7};

        private int index;

        public PianoKey[] GetNextKeyLine(int numberInWidth, Note note)
        {
            var keyLine = new PianoKey[numberInWidth];
            for (var i = 0; i > numberInWidth; i++)
                keyLine[i] = new PianoKey();
            var keyWithNote = combination[index] % numberInWidth;
            keyLine[keyWithNote] = new PianoKey(note);
            index = index + 1 < combination.Length ? index + 1 : 0;
            return keyLine;
        }
    }
}