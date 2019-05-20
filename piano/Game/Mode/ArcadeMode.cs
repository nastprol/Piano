using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Piano
{
    internal class ArcadeMode : IGameMode
    {
        private readonly Map map;
        private readonly Stopwatch sw; //
        private readonly Timer timer; //Mode update
        private int points;

        public ArcadeMode(Map map)
        {
            this.map = map;
            points = 0;
            sw = new Stopwatch();
            timer = new Timer {Interval = 1000};
            timer.Tick += TimerTick;
        }

        public int GetPoints()
        {
            return points;
        }

        public long GetTime()
        {
            return sw.ElapsedMilliseconds;
        }

        public bool IsGameEnd()
        {
            return false;
        }

        public void PrimaryPreparation()
        {
            timer.Start();
            sw.Start();
        }

        public void Update(bool isGameEnd)
        {
            if (isGameEnd)
                sw.Stop();
            else
                points = (int) sw.ElapsedMilliseconds / 100;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            map.MapUpdate();
        }
    }
}