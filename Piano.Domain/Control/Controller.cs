using Domain;
using System;

namespace Domain
{
    public class Controller
    {
        private IInputControl controlType;
        private readonly GameState game;
        private readonly InputControlSettings settings;

        public Controller(GameState game, InputControlSettings settings, IInputControlChanger changer)
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