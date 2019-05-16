using System.Linq;

namespace Piano
{
    public class GameState
    {
        private readonly Map map;
        private readonly IGameMode gameMode;
        private int index;
        private bool isFirstMove = true;
        private readonly IMapChange mapChange;
        private readonly Melody melody;
        private readonly int melodyLength;

        public GameState(IGameMode mode, IMapChange mapChange, Melody melody, int width, int high)
        {
            map = new Map(width, high);
            gameMode = mode;
            this.mapChange = mapChange;
            this.melody = melody;
            melodyLength = melody.Notes.Count();
        }

        public int GetPoints => gameMode.GetPoints();

        public long GetTime => gameMode.GetTime();

        public bool IsGameEnd { get; private set; }

        public PianoKey[,] GetMap => map.Keys;

        public void MakeMove(int keyNumber)
        {
            if (isFirstMove)
            {
                gameMode.PrimaryPreparation();
                for (var i = 0; i < map.NumberInHigh; i++)
                {
                    var note = melody.Notes.ElementAt(index);
                    index = index + 1 < melodyLength ? index + 1 : 0;
                    map.SetNextKeyLine(mapChange.GetNextKeyLine(map.NumberInWidth, note));
                }

                isFirstMove = false;
            }

            var firstLine = map.GetFirstLine();
            var pianoKey = firstLine[keyNumber];
            IsGameEnd = !pianoKey.isNote && gameMode.IsGameEnd();
            gameMode.Update(IsGameEnd);
            var nextNote = melody.Notes.ElementAt(index);
            index = index + 1 < melodyLength ? index + 1 : 0;
            map.SetNextKeyLine(mapChange.GetNextKeyLine(map.NumberInWidth, nextNote));
        }
    }
}