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
            controlType.Subscribe(this);
        }

        public void MakeStep(object sender, EventArgs e)
        {
            var inputKey = controlType.MakeInput(e);
            if (inputKey != null)
                game.MakeMove(inputKey.Value);
        }

        private void Update(object sender, EventArgs e)
        {
            controlType.Unsubscribe(this);
            controlType = settings.GetInputControlClass();
            controlType.Subscribe(this);
        }
    }
}