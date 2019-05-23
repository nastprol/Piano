using System.Collections.Generic;

namespace Piano
{
    public class GameSettings
    {
        private readonly Dictionary<string, IInputControl> inputControls = new Dictionary<string, IInputControl>();
        private readonly Dictionary<string, IGameMode> modes = new Dictionary<string, IGameMode>();
        private readonly Dictionary<string, IMelodyLoader> loaders = new Dictionary<string, IMelodyLoader>();
        private readonly Dictionary<string, IMelodyLocator> locators = new Dictionary<string, IMelodyLocator>();

        public string InputTypeName { private get; set; } = "MouseInputControl";
        public string ModeTypeName { private get; set; } = "ArcadeMode";
        public string LoaderTypeName { private get; set; } = "StandardMelodyLoader";
        public string MelodyLocator { private get; set; } = "StandardMelodyLocator";
        public string MelodyLocation { get; set; } = "1";

        public GameSettings(IInputControl[] inputControls, IGameMode[] modes, IMelodyLoader[] loaders, IMelodyLocator[] locators)
        {
            foreach (var c in inputControls)
                this.inputControls[c.GetType().Name] = c;
            foreach (var m in modes)
                this.modes[m.GetType().Name] = m;
            foreach (var l in loaders)
                this.loaders[l.GetType().Name] = l;
            foreach (var l in locators)
                this.locators[l.GetType().Name] = l;
        }

        public IInputControl GetInputControlClass() => inputControls[InputTypeName];
        public IMelodyLoader GetLoader() => loaders[LoaderTypeName];
        public IGameMode GetMode() => modes[ModeTypeName];
        public IMelodyLocator GetLocator() => locators[MelodyLocator];
    }
}
