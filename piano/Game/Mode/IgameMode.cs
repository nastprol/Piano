
namespace Piano
{
    public interface IGameMode
    {
        bool IsGameEnd();
        int GetPoints();
        long GetTime();
        void Update(bool isGameEnd, Map map, IMapChange mapChange, Melody melody, int index);
        void MapUpdate(Map map, IMapChange mapChange, Melody melody, int index, bool isFirstMove);
        void PrimaryPreparation();
    }
}
