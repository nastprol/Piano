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
                { "Seven Nation Army", new Melody(new[] { Note.F, Note.F, Note.GSharp, Note.F, Note.DSharp, Note.CSharp, Note.C,Note.F, Note.F, Note.GSharp, Note.F, Note.DSharp, Note.CSharp, Note.DSharp, Note.CSharp, Note.C }) },
                { "Елочка", new Melody(new[] { Note.C, Note.A, Note.A, Note.G, Note.A, Note.F, Note.C, Note.C,
                    Note.C, Note.A, Note.A, Note.A, Note.D, Note.C,
                    Note.C, Note.A, Note.A, Note.F, Note.F, Note.E, Note.D, Note.C,
                    Note.G, Note.E, Note.E, Note.D, Note.E, Note.C }) },
                { "Собачий вальс", new Melody(new[] { Note.DSharp, Note.CSharp, Note.FSharp, Note.ASharp, Note.ASharp, Note.DSharp, Note.CSharp, Note.FSharp, Note.ASharp, Note.ASharp,
                    Note.DSharp, Note.CSharp, Note.FSharp, Note.ASharp, Note.DSharp, Note.ASharp, Note.CSharp, Note.F, Note.F,  Note.DSharp, Note.CSharp, Note.CSharp , Note.F, Note.F, Note.DSharp, Note.CSharp, Note.CSharp , Note.F, Note.F,  Note.DSharp, Note.CSharp, Note.CSharp , Note.F, Note.DSharp, Note.F, Note.FSharp, Note.FSharp, Note.FSharp}) },
                {"Угадай мелодию", new Melody(new[]{Note.D, Note.G, Note.C2, Note.ASharp, Note.ASharp, Note.D, Note.G, Note.C2, Note.ASharp, Note.ASharp, Note.C, Note.G, Note.ASharp, Note.A, Note.A, Note.C, Note.G, Note.ASharp, Note.A, Note.A}) }
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