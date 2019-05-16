using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Piano
{
    public class KeyBoardInputControl : IInputControl
    {
        private Dictionary<int, int> controlKeys;
        public int InputValue { private set; get; }

        public KeyBoardInputControl(Dictionary<int, int> controlKeys)
        {
            this.controlKeys = controlKeys;
        }

        private void PressKey(object sender, EventArgs e)
        {
            var key = ((KeyEventArgs)e).KeyValue;
            if (controlKeys.ContainsKey(key))
                InputValue = controlKeys[key];
        }
    }
}
