using System.Collections.Generic;

namespace Piano
{
    public class LoaderSettings
    {
        private readonly Dictionary<string, IMelodyLoader> loaders = new Dictionary<string, IMelodyLoader>();
        private readonly GameSettings settings;

        public LoaderSettings(IMelodyLoader[] loaders, GameSettings settings)
        {
            this.settings = settings;

            foreach (var l in loaders)
                this.loaders[l.GetType().Name] = l;
        }

        public IMelodyLoader GetLoader()
        {
            return loaders[settings.LoaderTypeName];
        }
    }
}