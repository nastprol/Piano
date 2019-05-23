using System;
using Piano.Game.State;

namespace Piano
{
    public class Controller
    {
        private readonly IInputControl controlType;
        private readonly IGame game;

        public Controller(IInputControl controlType, IGame game)
        {
            this.controlType = controlType;
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