
namespace Piano
{
    public interface IGameMode
    {
        bool IsGameEnd();
        int GetPoints();
        long GetTime();
        void Update(bool isGameEnd);
        void PrimaryPreparation();
    }
}
