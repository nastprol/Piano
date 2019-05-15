using System.Linq;

namespace Piano
{
    class GameState
    {
        private IGameMode gameMode;
        private IKeyCombinations keyCombinations;
        private readonly Map map;
        private bool isGameEnd;
        private bool isFirstMove = true;
        private int index = 0;
        private int melodyLength;
        private Melody melody;

        public GameState(IGameMode mode, IKeyCombinations keyCombinations, Melody melody, int width, int high)
        {
            map = new Map(width, high);
            gameMode = mode;
            this.keyCombinations = keyCombinations;
            this.melody = melody;
            melodyLength = melody.Notes.Count();
        }

        public void MakeMove(int keyNumber)
        {
            if (isFirstMove)
            {
                gameMode.PrimaryPreparation();
                for (var i = 0; i < map.NumberInHigh; i++)
                {
                    var note = melody.Notes.ElementAt(index);
                    index = index + 1 < melodyLength ? index + 1 : 0;
                    map.SetNextKeyLine(keyCombinations.GetNextKeyLine(map.NumberInWidth,note));
                }
                isFirstMove = false;
            }
            var firstLine = map.GetFirstLine();
            var pianoKey = firstLine[keyNumber];
            isGameEnd = !pianoKey.isNote && gameMode.IsGameEnd();
            gameMode.Update(isGameEnd);
            var nextNote = melody.Notes.ElementAt(index);
            index = index + 1 < melodyLength ? index + 1 : 0;
            map.SetNextKeyLine(keyCombinations.GetNextKeyLine(map.NumberInWidth, nextNote));

        }

        public int GetPoints => gameMode.GetPoints();

        public long GetTime => gameMode.GetTime();

        public bool IsGameEnd => isGameEnd;

        public PianoKey[,] GetMap => map.Keys;
    }
}
