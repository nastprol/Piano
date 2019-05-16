using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Piano
{
    public class KeyBoardInputControl : IInputControl
    {
        private Dictionary<Keys, int> controlKeys;
        public int InputValue { private set; get; }

        public KeyBoardInputControl(Dictionary<Keys, int> controlKeys)
        {
            this.controlKeys = controlKeys;
        }

        public int InputValue { private set; get; }

        public void Subscribe(Form form, Сontroller сontroller)
        {
            form.Click += сontroller.MakeStep;
        }

        public bool MakeInput(EventArgs e)
        {
            var key = ((KeyEventArgs)e).KeyData;
            var contains = controlKeys.ContainsKey(key);
            if (contains)
                InputValue = controlKeys[key];
            return contains;
        }
    }
}