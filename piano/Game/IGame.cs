using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    interface IGame
    {
        Note MakeMove(int keyNumber);
        int GetPoints { get; }
        long GetTime { get; }
        bool IsGameEnd { get; }
        Map GetMap();
    }
}
