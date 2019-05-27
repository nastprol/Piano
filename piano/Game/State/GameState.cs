using Piano.Game.State;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Piano
{
    public class GameState : IGame
    {
        private bool isFirstMove = true;
        private readonly IGameMode mode;
        public int GetPoints { get; private set; }
        public bool IsGameEnd { get; private set; }
        public int MapShiftFromBottom => mode.MapShiftFromBottom;

        public GameState(GameSettings settings, Map map)
        {
            IsGameEnd = false;
            GetPoints = 0;
            mode = settings.GetMode();
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
            IsGameEnd = mode.UpdateIsGameEnd(true, isFirstMove);
            mode.UpdateTimerTick(isFirstMove);
        }
        
        private void Update(bool isPressNote)
        {
            IsGameEnd = mode.UpdateIsGameEnd(isPressNote, isFirstMove);
            if (!IsGameEnd)
            {
                GetPoints = mode.UpdatePoints(GetPoints);
                mode.Update();
            }
        }
    }
}