using System.Collections.Generic;
using System.Windows.Forms;
using Piano.Game.State;

namespace Piano
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IGameMode mode = new ArcadeMode();
            IMapChange change = new RandKeyMapChange();
            IMelodyLoader loader = new StandardMelodyLoader();
            var melody = loader.Load("1");
            IGame game = new GameState(mode, change, melody, 4, 4);
            var form = new GameForm(game);

            var keys = new Dictionary<Keys, int> { { Keys.Q, 0 }, { Keys.W, 1 }, { Keys.E, 2 }, { Keys.R, 3 }};
            IInputControl control = new KeyBoardInputControl(keys);        
            var controlerl = new Сontroller(control, game, form);

            Application.Run(form);
        }
    }
}