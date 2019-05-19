using System;
using System.Windows.Forms;
using Piano.Game;
using Piano.Game.State;

namespace Piano
{
    public class Controller
    {
        private readonly IInputControl controlType;
        private readonly IGame game;

        public event Action GameOver;

        public Controller(IInputControl controlType, IGame game)
        {
            this.controlType = controlType;
            this.game = game;
        }

        public void Subscribe(Form form)
        {
            controlType.Subscribe(form, this);
        }

        public Note Note { get; private set; }

        public void MakeStep(object sender, EventArgs e) 
        {
            if (!controlType.MakeInput(e))
                return;
            Note = game.MakeMove(controlType.InputValue);
            if (game.IsGameEnd)
                GameOver?.Invoke();
        }
    }
}