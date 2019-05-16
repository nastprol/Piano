using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    public class StandardMelodyLoader : IMelodyLoader
    {
        private static Dictionary<string, Melody> standardMelodies;

        static StandardMelodyLoader()
        {
            standardMelodies = new Dictionary<string, Melody>();
            var melodie = new Melody(new List<Note> { Note.Do, Note.Re, Note.Mi, Note.Fa, Note.Si });
            standardMelodies.Add("1", melodie);
        }

        public Melody Load(string name)
        {
            return standardMelodies[name];
        }
    }
}
