
using System.Diagnostics;

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


        public void Update(bool isGameEnd)
        {
            if (isGameEnd)
                timer.Stop();
            else
                points = (int)timer.ElapsedMilliseconds / 100;
        }
        
        public int GetPoints() => points;

        public long GetTime() => timer.ElapsedMilliseconds;

        public bool IsGameEnd() => false;

        public void PrimaryPreparation()
        {
            timer.Start();
        }
    }
}
