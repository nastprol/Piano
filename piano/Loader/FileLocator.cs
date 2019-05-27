namespace Piano
{
    [Description("Загрузить мелодию из файла")]
    public class FileLocator : IMelodyLocator
    {
        private readonly string path;

        public FileLocator(GameSettings settings)
        {
            this.path = settings.MelodyLocation;
        }

        public string GetLocation()
        {
            return path;
        }
    }
}