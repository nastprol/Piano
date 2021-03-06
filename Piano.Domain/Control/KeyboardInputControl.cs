﻿using Domain.Infrastructure;
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

        public event EventHandler<InputEventArgs> Input;

        public KeyBoardInputControl(KeyBoardSettings settings, IKeyInput input)
        {
            this.input = input;
            controlKeys = settings.ControlTools;
        }

        public void MakeInput(object sender, KeyEventArgs e)
        {
            var key = e.KeyCode;
            if (controlKeys.ContainsKey(key))
                Input.Invoke(this, new InputEventArgs(controlKeys[key]));
        }

        public void Subscribe()
        {
            input.KeyDown += MakeInput;
        }

        public void Unsubscribe()
        {
            input.KeyDown -= MakeInput;
        }
    }
}