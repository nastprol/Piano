using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Piano.Control;

namespace Piano
{
    public class KeyBoardInputControl : IInputControl
    {
        private readonly IKeyInput input;
        private readonly IReadOnlyDictionary<Keys, int> controlKeys;

        public KeyBoardInputControl(ISettings<Keys> settings, IKeyInput input)
        {
            this.input = input;
            controlKeys = settings.ControlTools;
        }

        public int InputValue { private set; get; }

        public void Subscribe(Controller controller)
        {
            input.KeyDown += controller.MakeStep;
        }

        public bool MakeInput(EventArgs e)
        {
            var key = ((KeyEventArgs) e).KeyCode;
            var contains = controlKeys.ContainsKey(key);
            if (contains)
                InputValue = controlKeys[key];
            return contains;
        }
    }
}