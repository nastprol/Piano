using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    class TestMapChange : IMapChange
    {
        public PianoKey[] GetNextKeyLine(int numberInWidth, Note note)
        {
            var keyLine = new PianoKey[numberInWidth];
            for (var i = 0; i < numberInWidth; i++)
                keyLine[i] = new PianoKey();
            keyLine[0] = new PianoKey(note);
            return keyLine;
        }
    }
}
