using System.Diagnostics;

namespace Piano
{
    public class ClassicMode : IGameMode
    {
        private const int Limit = 60000;
        private readonly Map map;
        private readonly Stopwatch sw;
        private int points;

        public ClassicMode(Map map)
        {
            this.map = map;
            sw = new Stopwatch();
            points = 0;
        }

        public int GetPoints()
        {
            return points;
        }

        public long GetTime()
        {
            return Limit - sw.ElapsedMilliseconds;
        }

        public bool IsGameEnd()
        {
            return sw.ElapsedMilliseconds >= Limit;
        }

        public void PrimaryPreparation()
        {
            sw.Start();
        }

        public void Update(bool isGameEnd)
        {
            if (isGameEnd)
            {
                sw.Stop();
            }
            else
            {
                points++;
                map.MapUpdate();
            }
        }
    }
}