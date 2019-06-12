using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Domain.Infrastructure
{
    [Description("Загрузить мелодию из файла")]
    public class MelodyFileLoader : IMelodyLoader
    {
        private static readonly Dictionary<string, Note> Notes = NoteSettings.Notes;
        private readonly GameSettings settings;
        private string location;
        private Melody melody = null;

        public MelodyFileLoader(ILocationChanger locationChanger, GameSettings settings)
        {
            this.settings = settings;
            location = settings.MelodyLocation;
            locationChanger.LocationChange += UpdateLocation;
        }

        private void UpdateLocation(object sender, EventArgs e)
        {
            location = settings.MelodyLocation;
        }

        public Melody Load()
        {
            try
            {
                string text;
                using (var sr = new StreamReader(location, Encoding.Default))
                {
                    text = sr.ReadToEnd();
                }

                var notes = ParseTextToNotes(text).ToArray();
                melody = new Melody(notes);
                return melody;
            }
            catch
            {
                return StandardMelodyLoader.StandardMelodies.First().Value;
            }
        }

        public IEnumerable<Note> ParseTextToNotes(string text)
        {
            return text.Split().Select(n => Notes[n]);
        }

        public IEnumerable<Melody> Melodies => new Melody[1] { melody };
    }
}