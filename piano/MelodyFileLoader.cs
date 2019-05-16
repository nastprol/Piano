using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Piano
{
    public class MelodyFileLoader : IMelodyLoader
    {
        private static Dictionary<string, Note> notes = new Dictionary<string, Note>();

        static MelodyFileLoader()
        {
            ((Note[])Enum.GetValues(typeof(Note))).Select(n => notes[n.ToString()] = n);
        }

        public IEnumerable<Note> ParseTextToNotes(string text)
        {
            return text.Split().Select(n => notes[n]);
        }

        public Melody Load(string loadPath)
        {
            var text = "";
            try
            {
                using (StreamReader sr = new StreamReader(loadPath, System.Text.Encoding.Default))
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
    }
}
