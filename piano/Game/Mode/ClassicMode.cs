using System.Diagnostics;

namespace Piano
{
    public class ClassicMode : IGameMode
    {
        private const int Limit = 60000;
        private readonly Map map;
        private readonly Stopwatch timer;
        private int points;

        public ClassicMode(Map map)
        {
            this.map = map;
            timer = new Stopwatch();
            points = 0;
        }

        public int GetPoints()
        {
            return points;
        }

        public long GetTime()
        {
            return Limit - timer.ElapsedMilliseconds;
        }

        public bool IsGameEnd()
        {
            return timer.ElapsedMilliseconds >= Limit;
        }

        public void PrimaryPreparation()
        {
            timer.Start();
        }

        public void Update(bool isGameEnd)
        {
            if (isGameEnd)
            {
                timer.Stop();
            }
            else
            {
                points++;
                map.MapUpdate();
            }
        }
    }
}