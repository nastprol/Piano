namespace Piano
{
    [Description("Загрузить стандартную мелодию")]
    public class StandardMelodyLocator : IMelodyLocator
    {
        private readonly string index;

        public StandardMelodyLocator(GameSettings settings)
        {
            index = settings.MelodyLocation;
        }

        public string GetLocation()
        {
            return index;
        }
    }
}