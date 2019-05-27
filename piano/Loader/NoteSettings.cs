using System;
using System.Collections.Generic;
using System.Linq;

namespace Piano.Loader
{
    public static class NoteSettings
    {
        public static Dictionary<string, Note> Notes;

        static NoteSettings()
        {
            Notes = ((Note[]) Enum.GetValues(typeof(Note))).ToDictionary(n => n.ToString());
        }
    }
}