using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Piano.Control;

namespace Piano
{
    [Description("Управление клавиатурой")]
    public class KeyBoardInputControl : IInputControl
    {
        private readonly IKeyInput input;
        private readonly IReadOnlyDictionary<Keys, int> controlKeys;

        public KeyBoardInputControl(ISettings<Keys> settings, IKeyInput input)
        {
            this.input = input;
            controlKeys = settings.ControlTools;
        }

        public void Subscribe(Controller controller)
        {
            input.KeyDown += controller.MakeStep;
        }

        public int? MakeInput(EventArgs e)
        {
            var key = ((KeyEventArgs) e).KeyCode;
            if (controlKeys.ContainsKey(key))
                return controlKeys[key];
            return null;
        }
    }
}