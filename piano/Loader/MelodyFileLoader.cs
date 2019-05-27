using Piano.Loader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Piano
{
    [Description("Загрузить мелодию из файла")]
    public class MelodyFileLoader : IMelodyLoader
    {
        private static readonly Dictionary<string, Note> Notes = NoteSettings.Notes;
        private readonly LocatorSettings settings;

        public MelodyFileLoader(LocatorSettings settings)
        {
            this.settings = settings;
        }

        public Melody Load()
        {
            string text;
            var locator = settings.GetLocator();
            using (var sr = new StreamReader(locator.GetLocation(), Encoding.Default))
                text = sr.ReadToEnd();

            var notes = ParseTextToNotes(text).ToArray();
            return new Melody(notes);
        }

        public IEnumerable<Note> ParseTextToNotes(string text)
        {
            return text.Split().Select(n => Notes[n]);
        }
    }
}