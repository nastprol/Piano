using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    public class LoaderSettings
    {
        private readonly Dictionary<string, IMelodyLoader> loaders = new Dictionary<string, IMelodyLoader>();
        public IMelodyLoader GetLoader() => loaders[settings.LoaderTypeName];
        private readonly GameSettings settings;

        public LoaderSettings(IMelodyLoader[] loaders, GameSettings settings)
        {
            this.settings = settings;

            foreach (var l in loaders)
                this.loaders[l.GetType().Name] = l;
        }
    }
}
