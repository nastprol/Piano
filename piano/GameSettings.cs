using System.Collections.Generic;

namespace Piano
{
    public class GameSettings
    {
        private readonly Dictionary<string, IInputControl> inputControls = new Dictionary<string, IInputControl>();
        private readonly Dictionary<string, IGameMode> modes = new Dictionary<string, IGameMode>();
        private readonly Dictionary<string, IMelodyLoader> loaders = new Dictionary<string, IMelodyLoader>();

        public string InputTypeName { get; set; }
        public string ModeTypeName { get; set; }
        public string LoaderTypeName { get; set; }

        public GameSettings(IInputControl[] inputControls, IGameMode[] modes, IMelodyLoader[] loaders)
        {
            foreach (var c in inputControls)
                this.inputControls[c.GetType().Name] = c;
            foreach (var m in modes)
                this.modes[m.GetType().Name] = m;
            foreach (var l in loaders)
                this.loaders[l.GetType().Name] = l;
        }

        public IInputControl GetInputControlClass() => inputControls[InputTypeName];
        public IMelodyLoader GetLoader() => loaders[LoaderTypeName];
        public IGameMode GetMode() => modes[ModeTypeName];
    }
}
