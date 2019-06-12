using Domain.Infrastructure;
using System.Linq;

namespace Domain
{
    public class GameSettings
    {
        public string InputTypeName { get; set; } = typeof(MouseInputControl).Name;
        public string ModeTypeName { get; set; } = typeof(ArcadeMode).Name;
        public string LoaderTypeName { get; set; } = typeof(StandardMelodyLoader).Name;
        public string MelodyLocation { get; set; } = StandardMelodyLoader.StandardMelodies.Keys.First();
    }
}