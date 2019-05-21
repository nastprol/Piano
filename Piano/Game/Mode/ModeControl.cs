using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace Piano
{
    class ModeControl : IModeControl
    {
        private readonly Stopwatch sw; //
        private readonly Timer timer; //Mode update
        private readonly IGameMode mode;
        public int Points { get; private set; }
        public bool IsGameEnd { get; private set; }
        public int MapShiftFromBottom => mode.MapShiftFromBottom;

        public ModeControl(IGameMode mode)
        {
            sw = new Stopwatch();
            timer = new Timer { Interval = 1000 };
            timer.Tick += TimerTick;
            this.mode = mode;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            IsGameEnd = mode.UpdateIsGameEnd(true, sw.ElapsedMilliseconds);
            mode.UpdateTimerTick();
        }

        public void PrimaryPreparation()
        {
            timer.Start();
            sw.Start();
        }

        public long GetTime() => mode.GetTime(sw.ElapsedMilliseconds);
        public void Update(bool isPressNote)
        {
            IsGameEnd = mode.UpdateIsGameEnd(isPressNote, sw.ElapsedMilliseconds);
            if (IsGameEnd)
            {
                sw.Stop();
            }
            else
            {
                Points = mode.UpdatePoints(sw.ElapsedMilliseconds, Points);
                mode.Update();
            }
        }
    }
}
