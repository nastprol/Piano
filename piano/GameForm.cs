using System.Windows.Forms;
using Piano;

namespace piano
{
    public class GameForm : Form
    {
        private readonly GameState gameState;

        public GameForm(GameState gameState)
        {
            this.gameState = gameState;
        }
    }
}