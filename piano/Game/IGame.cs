using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano.Game
{
    public interface IGame
    {
        void MakeMove(int keyNumber);
    }
}
