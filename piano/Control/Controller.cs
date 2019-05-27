using System;

namespace Piano
{
    public class Controller
    {
        private readonly IInputControl controlType;
        private readonly GameState game;

        public Controller(GameState game, InputControlSettings settings)
        {
            this.controlType = settings.GetInputControlClass();
            this.game = game;
            controlType.Subscribe(this);
        }

        public Note Note { get; private set; }

        public void MakeStep(object sender, EventArgs e)
        {
            var inputKey = controlType.MakeInput(e);
            if (inputKey != null)
                Note = game.MakeMove(inputKey.Value);
        }
    }
}