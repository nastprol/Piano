using System;

namespace Piano
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
            controlType.Subscribe(this);
        }

        public Note Note { get; private set; }

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