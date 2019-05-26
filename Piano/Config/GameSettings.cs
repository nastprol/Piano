using System.Collections.Generic;

namespace Piano
{
    public class GameSettings
    {
        public string InputTypeName { get; set; } = "MouseInputControl";
        public string ModeTypeName { get; set; } = "ArcadeMode";
        public string LoaderTypeName { get; set; } = "StandardMelodyLoader";
        public string MelodyLocator { get; set; } = "StandardMelodyLocator";
        public string MelodyLocation { get; set; } = "1";
    }
}
