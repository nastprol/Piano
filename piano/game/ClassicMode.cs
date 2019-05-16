using System.Diagnostics;

namespace Piano
{
    public class ClassicMode : IGameMode
    {
        private readonly int limit = 60000;
        private int points;
        private readonly Stopwatch timer;

        public ClassicMode()
        {
            timer = new Stopwatch();
            points = 0;
        }

        public int GetPoints()
        {
            return points;
        }

        public long GetTime()
        {
            return timer.ElapsedMilliseconds;
        }

        public bool IsGameEnd()
        {
            return timer.ElapsedMilliseconds >= limit;
        }

        public void PrimaryPreparation()
        {
            timer.Start();
        }

        public void Update(bool isGameEnd)
        {
            if (isGameEnd)
                timer.Stop();
            else
                points++;
        }
    }
}