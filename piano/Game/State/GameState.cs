using System;

namespace Piano
{
    public class GameState
    {
        private IGameMode mode;
        private bool isFirstMove = true;
        private readonly int shift;
        private readonly ModeSettings settings;

        public GameState(Map map, ModeSettings settings, IModeChanger changer, KeySettings keySettings)
        {
            this.settings = settings;
            shift = keySettings.Height;
            IsGameEnd = false;
            GetPoints = 0;
            changer.ModeChange += Update;
            mode = settings.GetMode();
            Map = map;
        }

        private void Update(object sender, EventArgs e)
        {
            mode = settings.GetMode();
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