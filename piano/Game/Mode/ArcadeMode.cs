﻿namespace Piano
{
    internal class ArcadeMode : IGameMode
    {
        private int shift = 30;
        private readonly Map map;

        public int MapShiftFromBottom { get; private set; }

        public ArcadeMode(Map map)
        {
            this.map = map;
            MapShiftFromBottom = 0;
        }

        public long GetTime(long time) => time;

        public bool UpdateIsGameEnd(bool isPressNote, long time, bool isFirstMove)
        {
            if (isFirstMove) return false;
            return !isPressNote || MapShiftFromBottom < 0;
        }

        public void Update()
        {
            map.MapUpdate();
            MapShiftFromBottom+=shift;
        }

        public int UpdatePoints(long time, int point) => (int)time / 1000;

        public void UpdateTimerTick(bool isFirstMove)
        {
            if (isFirstMove) return;
            MapShiftFromBottom-=shift;
        }
    }
}