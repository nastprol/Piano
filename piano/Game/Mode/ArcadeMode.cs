
using System.Diagnostics;
using System.Linq;

namespace Piano
{
    class ArcadeMode : IGameMode
    {
        private int points;
        private Stopwatch timer;

        public ArcadeMode()
        {
            points = 0;
            timer = new Stopwatch();
        }
        
        public int GetPoints() => points;

        public long GetTime() => timer.ElapsedMilliseconds;

        public bool IsGameEnd() => false;

        public void PrimaryPreparation()
        {
            timer.Start();
        }

        public void Update(bool isGameEnd, Map map, IMapChange mapChange, Melody melody, int index)
        {
            if (isGameEnd)
                timer.Stop();
            else
                points = (int)timer.ElapsedMilliseconds / 100;
        }

        public void MapUpdate(Map map, IMapChange mapChange, Melody melody, int index, bool isFirstMove)
        {
            if (isFirstMove)
            {
                for (var i = 0; i < map.NumberInHigh; i++)
                {
                    var note = melody.Notes.ElementAt(index);
                    index = index + 1 < melody.Notes.Count() ? index + 1 : 0;
                    map.SetNextKeyLine(mapChange.GetNextKeyLine(map.NumberInWidth, note));
                }
                return;
            }
            var nextNote = melody.Notes.ElementAt(index);
            map.SetNextKeyLine(mapChange.GetNextKeyLine(map.NumberInWidth, nextNote));
        }
    }
}
