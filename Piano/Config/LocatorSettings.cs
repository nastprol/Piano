using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    public class LocatorSettings
    {
        private readonly Dictionary<string, IMelodyLocator> locators = new Dictionary<string, IMelodyLocator>();
        public IMelodyLocator GetLocator() => locators[settings.MelodyLocator];

        private readonly GameSettings settings;

        public LocatorSettings(IMelodyLocator[] locators, GameSettings settings)
        {
            this.settings = settings;

            foreach (var l in locators)
                this.locators[l.GetType().Name] = l;
        }
    }
}
