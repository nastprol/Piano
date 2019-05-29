using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IGameState
    {
        void MakeMove(int keyNumber);
        int GetPoints { get; }
        bool IsGameEnd { get; }
        Map Map { get; }
        int MapShiftFromBottom { get; }
        event Action<Note> NoteClick;
        event Action Start;
        void Update();
    }
}
