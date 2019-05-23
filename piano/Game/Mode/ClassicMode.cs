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
        

        public bool UpdateIsGameEnd(bool isPressNote, bool isFirstMove)
        {
            if (isFirstMove) return false;
            return !isPressNote;
        }
        

        public void Update()
        {
           map.MapUpdate();
        }

        public int UpdatePoints(int point) => point + 1;

        public void UpdateTimerTick(bool isFirstMove)
        {
           
        }
    }
}