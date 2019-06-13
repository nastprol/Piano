using Domain.Infrastructure;
using System.Collections.Generic;

namespace Domain
{
    public class LoaderSettings : ILoaderSettings
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