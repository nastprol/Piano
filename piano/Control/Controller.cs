using System;
using System.Windows.Forms;
using Piano.Game;
using Piano.Game.State;

namespace Piano
{
    public class Controller
    {
        private readonly IInputControl controlType;
        private readonly Form form;
        private readonly IGame game;

        public event Action gameOver;

        public Controller(IInputControl controlType, IGame game, Form form)
        {
            this.controlType = controlType;
            this.form = form;
            this.game = game;
            controlType.Subscribe(form, this);
        }

        public Note Note { get; private set; }

        public void MakeStep(object sender, EventArgs e)
        {
            if (!controlType.MakeInput(e))
                return;
            Note = game.MakeMove(controlType.InputValue);
            if (game.IsGameEnd)
                gameOver?.Invoke();
        }
    }
}