namespace Piano
{
    public interface IGameMode
    {
        bool UpdateIsGameEnd(bool isPressNote, long time);
        void Update();
        void UpdateTimerTick();
        int UpdatePoints(long time, int point);
        long GetTime(long time);
        int MapShiftFromBottom { get; }
    }
}