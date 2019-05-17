using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Piano
{
    public class MelodyFileLoader : IMelodyLoader
    {
        private static readonly Dictionary<string, Note> notes;

        static MelodyFileLoader()
        {
            notes = ((Note[])Enum.GetValues(typeof(Note))).ToDictionary(n => n.ToString());
        }

        public Melody Load(string loadPath)
        {
            var text = "";
            try
            {
                using (var sr = new StreamReader(loadPath, Encoding.Default))
                {
                    text = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            var notes = ParseTextToNotes(text);
            return new Melody(notes);
        }

        public IEnumerable<Note> ParseTextToNotes(string text)
        {
            return text.Split().Select(n => notes[n]);
        }
    }
}