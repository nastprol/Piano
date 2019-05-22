using System.Collections.Generic;

namespace Piano
{
    public class StandardMelodyLoader : IMelodyLoader
    {
        private static readonly Dictionary<string, Melody> StandardMelodies;

        static StandardMelodyLoader()
        {
            StandardMelodies = new Dictionary<string, Melody>();
            var melody = new Melody(new []{Note.Do, Note.Re, Note.Mi, Note.Fa, Note.Si});
            StandardMelodies.Add("1", melody);
        }

        public Melody Load(IMelodyLocator locator)
        {
            return StandardMelodies[locator.GetLocation()];
        }
    }
}