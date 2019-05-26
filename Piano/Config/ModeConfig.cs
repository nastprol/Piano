using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    public class ModeConfig
    {
        private readonly Dictionary<string, IGameMode> modes = new Dictionary<string, IGameMode>();
        public IGameMode GetMode() => modes[settings.ModeTypeName];

        private readonly GameSettings settings;

        public ModeConfig(IGameMode[] modes, GameSettings settings)
        {
            this.settings = settings;

            foreach (var l in modes)
                this.modes[l.GetType().Name] = l;
        }
    }
}

