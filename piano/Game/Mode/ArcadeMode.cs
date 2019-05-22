namespace Piano
{
    internal class ArcadeMode : IGameMode
    {
        private readonly Map map;

        public int MapShiftFromBottom { get; private set; }

        public ArcadeMode(Map map)
        {
            this.map = map;
            MapShiftFromBottom = 0;
        }

        public long GetTime(long time) => time;

        public bool UpdateIsGameEnd(bool isPressNote, long time)
        {
            return !isPressNote || !map.IsFirstLineWithoutNote();
        }

        public void Update()
        {
            map.MapUpdate();
            MapShiftFromBottom++;
        }

        public int UpdatePoints(long time, int point) => (int)time / 1000;

        public void UpdateTimerTick()
        {
            MapShiftFromBottom--;
        }
    }
}