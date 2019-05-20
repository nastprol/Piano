using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Piano.Game.State;

namespace Piano
{
    class ArcadeMode : IGameMode
    {
        private IGame state;
        private Map map;
        private int points;
        private readonly Stopwatch sw;  //
        private readonly Timer timer; //Mode update

        public ArcadeMode(Map map)
        {
            this.map = map;
            points = 0;
            sw = new Stopwatch();
            timer = new Timer { Interval = 1000 };
            timer.Tick += TimerTick;
        }

        public void AddGame(IGame game)
        {
            state = game;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            map.MapUpdate();
        }

        public int GetPoints() => points;

        public long GetTime() => sw.ElapsedMilliseconds;

        public bool IsGameEnd() => false;

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
                points = (int)sw.ElapsedMilliseconds / 100;
        }

        public void MapUpdate()
        {
        }
    }
}
