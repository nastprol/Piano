using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Piano.Game.State;

namespace Piano
{
    class ArcadeMode : IGameMode
    {
        private readonly Map map;
        private readonly IMapChange mapChange;
        private readonly Melody melody;
        private IGame state;
        private int points;
        private readonly Stopwatch sw;  //
        private readonly Timer timer; //Mode update

        public ArcadeMode(Map map, IMapChange mapChange, Melody melody)
        {
            this.map = map;
            this.mapChange = mapChange;
            this.melody = melody;
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
            state.UpdateMap();
        }

        public int GetPoints() => points;

        public long GetTime() => sw.ElapsedMilliseconds;

        public bool IsGameEnd() => false;

        public void PrimaryPreparation()
        {
            timer.Start();
            sw.Start();
        }

        public void Update(bool isGameEnd, int index)
        {
            if (isGameEnd)
                sw.Stop();
            else
                points = (int)sw.ElapsedMilliseconds / 100;
        }

        public void MapUpdate(int index)
        {
            var nextNote = melody.Notes.ElementAt(index);
            map.SetNextKeyLine(mapChange.GetNextKeyLine(map.NumberInWidth, nextNote));
        }
    }
}
