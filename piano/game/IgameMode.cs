
namespace Piano
{
    public interface IGameMode
    {
        bool IsGameEnd();
        int GetPoints();
        long GetTime();
        void ChangeMap(Map map);
        void Update(bool isGameEnd);
        void PrimaryPreparation();
    }
}
