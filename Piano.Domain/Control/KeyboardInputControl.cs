using Domain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Domain
{
    [Description("Управление клавиатурой")]
    public class KeyBoardInputControl : IInputControl
    {
        private readonly IReadOnlyDictionary<Keys, int> controlKeys;
        private readonly IKeyInput input;

        public KeyBoardInputControl(KeyBoardSettings settings, IKeyInput input)
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

        public void Unsubscribe(Controller controller)
        {
            input.KeyDown -= controller.MakeStep;
        }
    }
}