using System;
using System.Diagnostics;

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

        public void ChangeMap(Map map)
        {
            throw new NotImplementedException();
        }

        public int GetPoints() => points;

        public long GetTime() => timer.ElapsedMilliseconds;

        public bool IsGameEnd() => timer.ElapsedMilliseconds >= limit;

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
