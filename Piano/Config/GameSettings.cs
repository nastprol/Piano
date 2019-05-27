namespace Piano
{
    public class GameSettings
    {
        public string InputTypeName { get; set; } = typeof(MouseInputControl).Name;
        public string ModeTypeName { get; set; } = typeof(ArcadeMode).Name;
        public string LoaderTypeName { get; set; } = typeof(StandardMelodyLoader).Name;
        public string MelodyLocator { get; set; } = typeof(StandardMelodyLocator).Name;
        public string MelodyLocation { get; set; } = "1";
    }
}
