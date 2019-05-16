using System;
using System.Diagnostics;
using System.Linq;

namespace Piano
{
    public class ClassicMode : IGameMode
    {
        private int points;
        private Stopwatch timer;
        private int limit = 60000;

        public ClassicMode()
        {
            timer = new Stopwatch();
            points = 0;
        }

        public int GetPoints() => points;

        public long GetTime() => timer.ElapsedMilliseconds;

        public bool IsGameEnd() => timer.ElapsedMilliseconds >= limit;

        public void PrimaryPreparation()
        {
            timer.Start();
        }

        public void Update(bool isGameEnd, Map map, IMapChange mapChange, Melody melody, int index)
        {
            if (isGameEnd)
                timer.Stop();
            else
            {
                points++;
                var nextNote = melody.Notes.ElementAt(index);
                map.SetNextKeyLine(mapChange.GetNextKeyLine(map.NumberInWidth, nextNote));
            }
        }

        public void MapUpdate(Map map, IMapChange mapChange, Melody melody, int index)
        {
        }

    }
}
