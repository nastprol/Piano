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
        private Note GetNote(string noteName)
        {
            foreach (var n in (Note[])Enum.GetValues(typeof(Note)))
            {
                if (n.ToString() == noteName)
                    return n;
            }
            throw new ArgumentException();
        }

        public IEnumerable<Note> ParseTextToNotes(string text)
        {
            Note.Do.ToString();
            return text.Split().Select(n => GetNote(n));
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
