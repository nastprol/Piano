using System;
using System.Linq;
using Piano.Game.State;

namespace Piano
{
    public class GameState : IGame
    {
        private readonly IGameMode gameMode;
        private readonly Map map;
        private bool isFirstMove = true;
        private int index;
        private readonly int melodyLength;

        public GameState(IGameMode mode, Melody melody, Map map)
        {
            //map = new Map(width, high, melody, mapChange);
            index = map.NumberInHigh;
            gameMode = mode;
            this.map = map;
            melodyLength = melody.Notes.Count();
            mode.AddGame(this);
        }

        public Note MakeMove(int keyNumber)
        {
            if (isFirstMove)
            {
                gameMode.PrimaryPreparation();
                isFirstMove = false;
            }
            var firstLine = map.GetFirstLine();
            var pianoKey = firstLine[keyNumber];
            IsGameEnd = !pianoKey.isNote || gameMode.IsGameEnd();
            index = index + 1 < melodyLength ? index + 1 : 0;
            gameMode.Update(IsGameEnd, index);

            return pianoKey.Note;

        }

        public void UpdateMap()
        {
            gameMode.MapUpdate(index);
        }

        public int GetPoints => gameMode.GetPoints();

        public long GetTime => gameMode.GetTime();

        public bool IsGameEnd { get; private set; }

        public Map GetMap()
        {
            //gameMode.MapUpdate(index, isFirstMove);
            return map;
        }
    }
}
