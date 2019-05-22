namespace Piano
{
    public interface IModeControl
    {
        int Points { get; }
        bool IsGameEnd { get; }
        void PrimaryPreparation();
        long GetTime();
        void Update(bool isPressNote);
        int MapShiftFromBottom { get; }
    }
}
