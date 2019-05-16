using System;
using System.Windows.Forms;

namespace Piano
{
    public class Сontroller
    {
        private readonly IInputControl controlType;
        private readonly Form form;
        private readonly GameState game;

        public Сontroller(IInputControl controlType, IGame game, Form form)
        {
            this.controlType = controlType;
            this.form = form;
            controlType.Subscribe(form, this);
        }

        public Note Note { get; private set; }

        public void MakeStep(object sender, EventArgs e)
        {
            if (controlType.MakeInput(e))
                try
                {
                    Note = game.MakeMove(controlType.InputValue);
                }
                catch
                {
                    form.Close();
                }
        }
    }
}