namespace Piano
{
    public interface IGameMode
    {
        bool UpdateIsGameEnd(bool isPressNote, long time,bool isFirstMove);
        void Update();
        void UpdateTimerTick(bool isFirstMove);
        int UpdatePoints(long time, int point);
        long GetTime(long time);
        int MapShiftFromBottom { get; }
    }
}