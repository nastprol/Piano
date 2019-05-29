namespace Domain
{
    public interface IGameMode
    {
        int MapShiftFromBottom { get; }
        bool CheckIsGameEnd(bool isPressNote, bool isFirstMove);
        void Update(int shift);
        void UpdateTimerTick(bool isFirstMove);
        int AddPoints(int point);
    }
}