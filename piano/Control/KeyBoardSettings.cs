using System.Collections.Generic;
using System.Windows.Forms;

namespace Piano
{
    public class KeyBoardSettings
    {
        public Dictionary<Keys, int> ControlKeys = new Dictionary<Keys, int> { { Keys.Q, 0 }, { Keys.W, 1 }, { Keys.E, 2 }, { Keys.R, 3 } };
    }
}