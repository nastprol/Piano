using Domain;
using Domain.Infrastructure;
using System;

namespace App
{
    public class Controller
    {
        private IInputControl controlType;
        private readonly GameState game;
        private readonly IInputControlSettings settings;

        public Controller(GameState game, IInputControlSettings settings, IInputControlChanger changer)
        {
            this.settings = settings;
            controlType = settings.GetInputControlClass();
            changer.InputTypeChange += Update;
            this.game = game;

            controlType.Input += MakeStep;
            controlType.Subscribe();
        }

        public void MakeStep(object sender, InputEventArgs e)
        {
            var inputKey = e.KeyNumber;
            game.MakeMove(inputKey);
        }

        private void Update(object sender, EventArgs e)
        {
            controlType.Unsubscribe();
            controlType.Input -= MakeStep;
            controlType = settings.GetInputControlClass();
            controlType.Input += MakeStep;
            controlType.Subscribe();
        }
    }
}