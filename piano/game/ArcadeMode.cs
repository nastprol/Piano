using System.Diagnostics;

namespace Piano
{
    internal class ArcadeMode : IGameMode
    {
        private int points;
        private readonly Stopwatch timer;

        public ArcadeMode()
        {
            points = 0;
            timer = new Stopwatch();
        }


        public void Update(bool isGameEnd)
        {
            if (isGameEnd)
                timer.Stop();
            else
                points = (int) timer.ElapsedMilliseconds / 100;
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
            return false;
        }

        public void PrimaryPreparation()
        {
            timer.Start();
        }
    }
}