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
        DateTime GetTime();
        void ChangeMap(Map map);
        void AddPoints(bool isGameEnd);
    }
}
