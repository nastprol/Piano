using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using piano.GUI;
using Piano.Game;
using Piano.Game.State;

namespace Piano
{
    class Program
    {
        static void Main(string[] args)
        {
            IGameMode mode = new ClassicMode();
            IMapChange change = new RandKeyMapChange();
            IMelodyLoader loader = new StandardMelodyLoader();
            var melody = loader.Load("1");
            IGame game = new GameState(mode, change, melody, 4, 4);
            var form = new GameForm(game);

            var keys = new Dictionary<Keys, int> { { Keys.Q, 0 }, { Keys.W, 1 }, { Keys.E, 2 }, { Keys.R, 3 }};
            IInputControl control = new KeyBoardInputControl(keys);        
            Сontroller controlerl = new Сontroller(control, game, form);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form);
        }
    }
}
