namespace Piano
{
    public class StandardMelodyLocator : IMelodyLocator
    {
        private readonly string index;

        public StandardMelodyLocator(int index)
        {
            this.index = index.ToString();
        }

        public string GetLocation()
        {
            return index;
        }
    }
}