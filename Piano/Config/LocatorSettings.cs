using System.Collections.Generic;

namespace Piano
{
    public class LocatorSettings
    {
        private readonly Dictionary<string, IMelodyLocator> locators = new Dictionary<string, IMelodyLocator>();

        private readonly GameSettings settings;

        public LocatorSettings(IMelodyLocator[] locators, GameSettings settings)
        {
            this.settings = settings;

            foreach (var l in locators)
                this.locators[l.GetType().Name] = l;
        }

        public IMelodyLocator GetLocator()
        {
            return locators[settings.MelodyLocator];
        }
    }
}