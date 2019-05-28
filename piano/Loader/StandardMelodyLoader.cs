using System;
using System.Collections.Generic;

namespace Piano
{
    [Description("Загрузить стандартную мелодию")]
    public class StandardMelodyLoader : IMelodyLoader
    {
        public static readonly IReadOnlyDictionary<string, Melody> StandardMelodies;

        private readonly GameSettings gameSettings;
        private string location;

        static StandardMelodyLoader()
        {
            StandardMelodies = new Dictionary<string, Melody>{
                { "1", new Melody(new[] {Note.C, Note.D, Note.E, Note.F, Note.B}) },
                { "2", new Melody(new[] { Note.ASharp, Note.D, Note.E, Note.G, Note.CSharp, Note.ASharp, Note.A, Note.C, Note.F, Note.FSharp }) } };
        }

        public StandardMelodyLoader(ILocationChanger locationChanger, GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
            location = gameSettings.MelodyLocation;
            locationChanger.LocationChange += UpdateLocation;
        }

        private void UpdateLocation(object sender, EventArgs e)
        {
            location = gameSettings.MelodyLocation;
        }

        public Melody Load()
        {             
            return StandardMelodies[location];
        }
    }
}