namespace Piano
{
    public interface IGameMode
    {
        bool UpdateIsGameEnd(bool isPressNote, bool isFirstMove);
        void Update();
        void UpdateTimerTick(bool isFirstMove);
        int UpdatePoints( int point);
        int MapShiftFromBottom { get; }
    }
}