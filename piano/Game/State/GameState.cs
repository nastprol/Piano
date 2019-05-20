using Piano.Game.State;

namespace Piano
{
    public class GameState : IGame
    {
        private readonly IGameMode gameMode;
        private bool isFirstMove = true;

        public GameState(IGameMode mode, Map map)
        {
            gameMode = mode;
            Map = map;
        }

        public Map Map { get; }

        public Note MakeMove(int keyNumber)
        {
            if (isFirstMove)
            {
                gameMode.PrimaryPreparation();
                isFirstMove = false;
            }

            var firstLine = Map.GetFirstLine();
            var pianoKey = firstLine[keyNumber];
            IsGameEnd = !pianoKey.IsNote || gameMode.IsGameEnd();
            gameMode.Update(IsGameEnd);

            return pianoKey.Note;
        }

        public int GetPoints => gameMode.GetPoints();

        public long GetTime => gameMode.GetTime();

        public bool IsGameEnd { get; private set; }
    }
}