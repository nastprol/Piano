namespace Piano
{
    public class FileLocator : IMelodyLocator
    {
        private readonly string path;

        public FileLocator(string path)
        {
            this.path = path;
        }

        public string GetLocation()
        {
            return path;
        }
    }
}