using Domain.Infrastructure;
using System;

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
