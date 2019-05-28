namespace Domain
{
    internal class TestMapChange : IMapChange
    {
        public PianoKey[] GetNextKeyLine(int numberInWidth, Note note)
        {
            var keyLine = new PianoKey[numberInWidth];
            for (var i = 0; i < numberInWidth; i++)
                keyLine[i] = new PianoKey();
            keyLine[0] = new PianoKey(note);
            return keyLine;
        }
    }
}