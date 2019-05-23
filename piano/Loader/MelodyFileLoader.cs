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

        public Melody Load(IMelodyLocator locator)
        {
            string text;
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