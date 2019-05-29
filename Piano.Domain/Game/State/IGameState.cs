using System;

namespace Domain
{
    public interface IGameState
    {
        Map Map { get; }
        event Action<Note> NoteClick;
        event Action Start;
        int MapShiftFromBottom { get; }
        int GetPoints { get; }
        bool IsGameEnd { get; }
        void Update();
        void MakeMove(int keyNumber);
    }
}