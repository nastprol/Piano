using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    class GameState
    {
        private IGameMode gameMode;
        private readonly Map map;
        private bool isGameEnd;

        public GameState(IGameMode mode, int width, int high)
        {
            map = new Map(width, high);
            gameMode = mode;
        }

        public void MakeMove(int keyNumber)
        {
            var firstLine = map.GetFirstLine();
            var pianoKey = firstLine[keyNumber];
            isGameEnd = !pianoKey.isNote && gameMode.IsGameEnd();
            gameMode.ChangeMap(map);
            gameMode.AddPoints(isGameEnd);

        }

        public int GetPoints => gameMode.GetPoints();

        public DateTime GetTime => gameMode.GetTime();

        public bool IsGameEnd => isGameEnd;
    }
}
