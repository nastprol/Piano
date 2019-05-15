using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    class ArcadeMode : IGameMode
    {
        private int points;
        private Stopwatch timer;

        public ArcadeMode()
        {
            var timer = Stopwatch.StartNew();
            var time = timer.ElapsedMilliseconds;
            timer.Stop();
            var ti = timer.ElapsedMilliseconds;
        }
        public void Update(bool isGameEnd)
        {
            throw new NotImplementedException();
        }

        public void ChangeMap(Map map)
        {
            throw new NotImplementedException();
        }

        public int GetPoints()
        {
            throw new NotImplementedException();
        }

        public DateTime GetTime()
        {
            throw new NotImplementedException();
        }

        public bool IsGameEnd()
        {
            throw new NotImplementedException();
        }

        public void PrimaryPreparation()
        {
            throw new NotImplementedException();
        }

        long IGameMode.GetTime()
        {
            throw new NotImplementedException();
        }
    }
}
