using System.Diagnostics;

namespace Piano
{
    [Description("Классика")]
    public class ClassicMode : IGameMode
    {
        private const int Limit = 60000;
        private readonly Map map;

        public int MapShiftFromBottom => 0;

        public ClassicMode(Map map)
        {
            this.map = map;
        }        

        public long GetTime(long time) =>Limit - time;
        

        public bool UpdateIsGameEnd(bool isPressNote, long time, bool isFirstMove)
        {
            if (isFirstMove) return false;
            return !isPressNote || time >= Limit;
        }
        

        public void Update()
        {
           map.MapUpdate();
        }

        public int UpdatePoints(long time, int point) => point + 1;

        public void UpdateTimerTick(bool isFirstMove)
        {
           
        }
    }
}