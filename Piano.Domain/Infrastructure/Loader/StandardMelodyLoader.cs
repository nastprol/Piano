using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Infrastructure
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
                { "2", new Melody(new[] { Note.ASharp, Note.D, Note.E, Note.G, Note.CSharp, Note.ASharp, Note.A, Note.C, Note.F, Note.FSharp }) },
                { "Елочка", new Melody(new[] { Note.C, Note.A, Note.A, Note.G, Note.A, Note.F, Note.C, Note.C,
                    Note.C, Note.A, Note.A, Note.B, Note.C, Note.B,
                    Note.C, Note.D, Note.D, Note.B, Note.B, Note.A, Note.G, Note.F,
                    Note.C, Note.A, Note.A, Note.G, Note.A, Note.F }) },
                { "Собачий вальс", new Melody(new[] { Note.DSharp, Note.CSharp, Note.FSharp, Note.ASharp, Note.ASharp, Note.DSharp, Note.CSharp, Note.FSharp, Note.ASharp, Note.ASharp,
                    Note.DSharp, Note.CSharp, Note.FSharp, Note.ASharp, Note.DSharp, Note.ASharp, Note.CSharp, Note.E, Note.E }) }
            };
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
            if (!StandardMelodies.ContainsKey(location))
                return StandardMelodies.First().Value;
            return StandardMelodies[location];
        }
    }
}