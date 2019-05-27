using System.Collections.Generic;

namespace Piano
{
    [Description("Загрузить стандартную мелодию")]
    public class StandardMelodyLoader : IMelodyLoader
    {
        private static readonly Dictionary<string, Melody> StandardMelodies;
        private readonly LocatorSettings settings;

        static StandardMelodyLoader()
        {
            StandardMelodies = new Dictionary<string, Melody>();
            var melody = new Melody(new[] {Note.C, Note.D, Note.E, Note.F, Note.B});
            StandardMelodies.Add("1", melody);
        }

        public StandardMelodyLoader(LocatorSettings settings)
        {
            this.settings = settings;
        }

        public Melody Load()
        {
            var locator = settings.GetLocator();
            return StandardMelodies[locator.GetLocation()];
        }
    }
}