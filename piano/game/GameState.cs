using System;
using System.Linq;

namespace Piano
{
    public class GameState
    {
        private IGameMode gameMode;
        private IMapChange mapChange;
        private readonly Map map;
        private bool isGameEnd;
        private bool isFirstMove = true;
        private int index = 0;
        private int melodyLength;
        private Melody melody;

        public GameState(IGameMode mode, IMapChange mapChange, Melody melody, int width, int high)
        {
            map = new Map(width, high);
            gameMode = mode;
            this.mapChange = mapChange;
            this.melody = melody;
            melodyLength = melody.Notes.Count();
        }

        public Note MakeMove(int keyNumber)
        {
            if (isFirstMove)
            {
                gameMode.PrimaryPreparation();
                for (var i = 0; i < map.NumberInHigh; i++)
                {
                    var note = melody.Notes.ElementAt(index);
                    index = index + 1 < melodyLength ? index + 1 : 0;
                    map.SetNextKeyLine(mapChange.GetNextKeyLine(map.NumberInWidth,note));
                }
                isFirstMove = false;
            }
            var firstLine = map.GetFirstLine();
            var pianoKey = firstLine[keyNumber];
            isGameEnd = !pianoKey.isNote && gameMode.IsGameEnd();
            if (isGameEnd)
                throw new Exception();
            
            gameMode.Update(isGameEnd, map, mapChange,melody,index);         
            index = index + 1 < melodyLength ? index + 1 : 0;
            
            return pianoKey.Note;

        }

        public int GetPoints => gameMode.GetPoints();

        public long GetTime => gameMode.GetTime();

        public bool IsGameEnd => isGameEnd;

        public Map GetMap()
        {
            gameMode.MapUpdate(map, mapChange, melody, index);
            return map;
        }
    }
}
