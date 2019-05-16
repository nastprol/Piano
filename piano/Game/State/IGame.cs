using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano.Game.State
{
    public interface IGame
    {
        void MakeMove(int keyNumber);
        int GetPoints { get; }
        long GetTime { get; }
        bool IsGameEnd { get; }
        PianoKey[,] GetMap { get; }
    }
}
