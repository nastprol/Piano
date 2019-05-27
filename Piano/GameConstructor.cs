using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    public class GameConstructor
    {
        public GameForm Form { get; }
        public GameConstructor(GameForm form, Controller controller)
        {
            Form = form;
        }
    }
}
