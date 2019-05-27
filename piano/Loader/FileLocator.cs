namespace Piano
{
    [Description("Загрузить мелодию из файла")]
    public class FileLocator : IMelodyLocator
    {
        private readonly string path;

        public FileLocator(GameSettings settings)
        {
            path = settings.MelodyLocation;
        }

        public string GetLocation()
        {
            return path;
        }
    }
}