using System;

namespace Piano
{
    public class GameState
    {
        private readonly IGameMode mode;
        private bool isFirstMove = true;
        private readonly int shift;

        public GameState(Map map, ModeSettings settings, KeySettings keySettings)
        {
            shift = keySettings.Height;
            IsGameEnd = false;
            GetPoints = 0;
            mode = settings.GetMode();
            Map = map;
        }

        public int GetPoints { get; private set; }
        public bool IsGameEnd { get; private set; }
        public int MapShiftFromBottom => mode.MapShiftFromBottom;

        public Map Map { get; }

        public event Action<Note> NoteClick;
        public event Action Start;

        public void MakeMove(int keyNumber)
        {
            if (isFirstMove)
            {
                Start?.Invoke();
                isFirstMove = false;
            }

            var firstLine = Map.GetFirstLine();
            var pianoKey = firstLine[keyNumber];
            var isPressNote = pianoKey.IsNote;
            pianoKey.Press();
            Update(isPressNote);
            NoteClick?.Invoke(pianoKey.Note);
        }

        public void Update()
        {
            IsGameEnd = mode.CheckIsGameEnd(true, isFirstMove);
            mode.UpdateTimerTick(isFirstMove);
        }

        private void Update(bool isPressNote)
        {
            IsGameEnd = mode.CheckIsGameEnd(isPressNote, isFirstMove);
            if (IsGameEnd) return;
            GetPoints = mode.AddPoints(GetPoints);
            mode.Update(shift);
        }
    }
}