using System.Collections.Generic;

namespace Piano
{
    public class ModeSettings
    {
        private readonly Dictionary<string, IGameMode> modes = new Dictionary<string, IGameMode>();

        private readonly GameSettings settings;

        public ModeSettings(IGameMode[] modes, GameSettings settings)
        {
            this.settings = settings;

            foreach (var l in modes)
                this.modes[l.GetType().Name] = l;
        }

        public IGameMode GetMode()
        {
            return modes[settings.ModeTypeName];
        }
    }
}