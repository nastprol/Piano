using System.Diagnostics;

namespace Piano
{
    [Description("Классика")]
    public class ClassicMode : IGameMode
    {
        private readonly Map map;

        public int MapShiftFromBottom { get; private set; }

        public ClassicMode(Map map)
        {
            this.map = map;
            MapShiftFromBottom = 0;
        }        
        

        public bool CheckIsGameEnd(bool isPressNote, bool isFirstMove)
        {
            if (isFirstMove) return false;
            return !isPressNote;
        }

        public int AddPoints(int point) => point + 1;

        public void UpdateTimerTick(bool isFirstMove)
        {
            if (isFirstMove) return;
            MapShiftFromBottom -= 1;
        }

        public void Update(int shift)
        {
            map.MapUpdate();
            MapShiftFromBottom += shift;
        }
    }
}