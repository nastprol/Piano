
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Piano
{
    public class GameState 
    {

        private int shift = 30;
        private bool isFirstMove = true;
        private readonly IGameMode mode;
        public int GetPoints { get; private set; }
        public bool IsGameEnd { get; private set; }
        public int MapShiftFromBottom => mode.MapShiftFromBottom;

        public GameState(Map map, ModeConfig settings)
        {
            IsGameEnd = false;
            GetPoints = 0;
            this.mode = settings.GetMode();
            Map = map;
        }

        public Map Map { get; }

        public Note MakeMove(int keyNumber)
        {
            if (isFirstMove)
            {
                isFirstMove = false;
            }

            var firstLine = Map.GetFirstLine();
            var pianoKey = firstLine[keyNumber];
            var isPressNote = pianoKey.IsNote;
            pianoKey.Press();
            Update(isPressNote);
            return pianoKey.Note;
        }

        public void Update()
        {
            IsGameEnd = mode.CheckIsGameEnd(true, isFirstMove);
            mode.UpdateTimerTick(isFirstMove);
        }
        
        private void Update(bool isPressNote)
        {
            IsGameEnd = mode.CheckIsGameEnd(isPressNote, isFirstMove);
            if (!IsGameEnd)
            {
                GetPoints = mode.AddPoints(GetPoints);
                mode.Update(shift);
            }
        }
    }
}