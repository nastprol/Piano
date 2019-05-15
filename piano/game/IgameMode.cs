using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
