﻿using Domain;
using System;

namespace Domain
{
    public class Controller
    {
        private IInputControl controlType;
        private readonly IGameState game;
        private readonly InputControlSettings settings;

        public Controller(IGameState game, InputControlSettings settings, IInputControlChanger changer)
        {
            this.settings = settings;
            controlType = settings.GetInputControlClass();
            changer.InputTypeChange += Update;
            this.game = game;

            controlType.Input += MakeStep;
        }

        public void MakeStep(object sender, InputEventArgs e)
        {
            var inputKey = e.KeyNumber;
            game.MakeMove(inputKey);
        }

        private void Update(object sender, EventArgs e)
        {
            controlType.Input -= MakeStep;
            controlType = settings.GetInputControlClass();
            controlType.Input += MakeStep;
        }
    }
}