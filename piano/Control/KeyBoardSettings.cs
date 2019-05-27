using System.Collections.Generic;
using System.Windows.Forms;
using Piano.Control;

namespace Piano
{
    public class KeyBoardSettings 
    {
        private readonly Dictionary<Keys, int> controlKeys = new Dictionary<Keys, int>
        {
            {Keys.Q, 0}, {Keys.W, 1}, {Keys.E, 2}, {Keys.R, 3}
        };

        public IReadOnlyDictionary<Keys, int> ControlTools => controlKeys;
    }
}