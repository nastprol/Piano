namespace Piano
{
    public interface IGameMode
    {
        bool CheckIsGameEnd(bool isPressNote, bool isFirstMove);
        void Update(int shift);
        void UpdateTimerTick(bool isFirstMove);
        int AddPoints( int point);
        int MapShiftFromBottom { get; }
    }
}