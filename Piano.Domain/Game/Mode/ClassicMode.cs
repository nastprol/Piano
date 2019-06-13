using Domain.Infrastructure;

namespace Domain
{
    [Description("Классика")]
    public class ClassicMode : IGameMode
    {
        private readonly Map map;

        public ClassicMode(Map map)
        {
            this.map = map;
            MapShiftFromBottom = 0;
        }

        public int MapShiftFromBottom { get; private set; }


        public bool CheckIsGameEnd(bool isPressNote, bool isFirstMove)
        {
            if (isFirstMove) return false;
            return !isPressNote;
        }

        public int AddPoints(int point)
        {
            return point + 1;
        }

        public void UpdateTimerTick(bool isFirstMove)
        {
            if (isFirstMove) return;
            MapShiftFromBottom = MapShiftFromBottom > 0 ? MapShiftFromBottom - 15 : MapShiftFromBottom;
        }

        public void Update(int shift)
        {
            map.MapUpdate();
            MapShiftFromBottom += shift;
        }
    }
}