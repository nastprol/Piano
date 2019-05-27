namespace Piano.Game.State
{
    public interface IGame
    {
        int GetPoints { get; }
        bool IsGameEnd { get; }
        Map Map { get; }
        Note MakeMove(int keyNumber);

        int MapShiftFromBottom { get; }

        void Update();
    }
}