namespace Piano
{
    [Description("Аркада")]
    public class ArcadeMode : IGameMode
    {
        private readonly Map map;

        public ArcadeMode(Map map)
        {
            this.map = map;
            MapShiftFromBottom = 0;
        }

        public int MapShiftFromBottom { get; private set; }

        public bool CheckIsGameEnd(bool isPressNote, bool isFirstMove)
        {
            if (isFirstMove) return false;
            return !isPressNote || MapShiftFromBottom < -100;
        }

        public void Update(int shift)
        {
            map.MapUpdate();
            MapShiftFromBottom += shift;
        }

        public int AddPoints(int point)
        {
            return point + 1;
        }

        public void UpdateTimerTick(bool isFirstMove)
        {
            if (isFirstMove) return;
            MapShiftFromBottom -= 5;
        }
    }
}