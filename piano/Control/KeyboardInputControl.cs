﻿using Piano.Control;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Piano
{
    public class KeyBoardInputControl : IInputControl
    {
        private IReadOnlyDictionary<Keys, int> controlKeys;

        public KeyBoardInputControl(ISettings<Keys> settings)
        {
            controlKeys = settings.ControlTools;
        }

        public int InputValue { private set; get; }

        public void Subscribe(Form form, Controller controller)
        {
            form.KeyDown += controller.MakeStep;
        }

        public bool MakeInput(EventArgs e)
        {
            var key = ((KeyEventArgs)e).KeyCode;
            var contains = controlKeys.ContainsKey(key);
            if (contains)
                InputValue = controlKeys[key];
            return contains;
        }
    }
}