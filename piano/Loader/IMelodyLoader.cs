namespace Piano
{
    public interface IMelodyLoader
    {
        Melody Load(IMelodyLocator loadPath);
    }
}