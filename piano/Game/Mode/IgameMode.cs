
using Piano.Game.State;

namespace Piano
{
    public interface IGameMode
    {
        bool IsGameEnd();
        int GetPoints();
        long GetTime();
        void Update(bool isGameEnd);
        void MapUpdate();
        void PrimaryPreparation();

        void AddGame(IGame game);
    }
}
