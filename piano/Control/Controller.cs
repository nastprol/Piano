using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Piano.Game;
using Piano.Game.State;

namespace Piano
{
    public class Сontroller
    {
        private readonly IInputControl controlType;
        private readonly GameState game;
        private readonly Form form;

        public Note Note { get; private set; }

        public Сontroller(IInputControl controlType, IGame game, Form form)
        {
            this.controlType = controlType;
            this.form = form;
            controlType.Subscribe(form, this);
        }

        public void MakeStep(object sender, EventArgs e)
        {
            if (controlType.MakeInput(e))
            {
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
}
