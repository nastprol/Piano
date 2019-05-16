namespace Piano
{
    public interface IMapChange
    {
        PianoKey[] GetNextKeyLine(int numberInWidth, Note note);
    }
}