﻿using System.Collections.Generic;

namespace Piano
{
    [Description("Загрузить стандартную мелодию")]
    public class StandardMelodyLoader : IMelodyLoader
    {
        private static readonly Dictionary<string, Melody> StandardMelodies;
        private readonly GameSettings settings;

        static StandardMelodyLoader()
        {
            StandardMelodies = new Dictionary<string, Melody>();
            var melody = new Melody(new []{Note.Do, Note.Re, Note.Mi, Note.Fa, Note.Si});
            StandardMelodies.Add("1", melody);
        }

        public StandardMelodyLoader(GameSettings settings)
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