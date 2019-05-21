using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Piano
{
    public class MelodyFileLoader : IMelodyLoader
    {
        private static readonly Dictionary<string, Note> Notes;

        static MelodyFileLoader()
        {
            Notes = ((Note[])Enum.GetValues(typeof(Note))).ToDictionary(n => n.ToString());
        }

        public Melody Load(IMelodyLocator locator)
        {
            string text;
            using (var sr = new StreamReader(locator.GetLocation(), Encoding.Default))
                text = sr.ReadToEnd();

            var notes = ParseTextToNotes(text);
            return new Melody(notes);
        }

        public IEnumerable<Note> ParseTextToNotes(string text)
        {
            return text.Split().Select(n => Notes[n]);
        }
    }
}