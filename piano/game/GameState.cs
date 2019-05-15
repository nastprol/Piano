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
        private bool isFirstMove = true;

        public GameState(IGameMode mode, int width, int high)
        {
            map = new Map(width, high);
            gameMode = mode;
        }

        public void MakeMove(int keyNumber)
        {
            if (isFirstMove) gameMode.PrimaryPreparation();
            var firstLine = map.GetFirstLine();
            var pianoKey = firstLine[keyNumber];
            isGameEnd = !pianoKey.isNote && gameMode.IsGameEnd();
            gameMode.Update(isGameEnd);
            gameMode.ChangeMap(map);
            

        }

        public int GetPoints => gameMode.GetPoints();

        public long GetTime => gameMode.GetTime();

        public bool IsGameEnd => isGameEnd;
    }
}
