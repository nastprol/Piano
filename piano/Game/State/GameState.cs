using Piano.Game.State;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Piano
{
    public class GameState : IGame
    {
        private bool isFirstMove = true;
        private readonly Stopwatch sw; 
        private readonly IGameMode mode;
        public int GetPoints { get; private set; }
        public bool IsGameEnd { get; private set; }
        public int MapShiftFromBottom => mode.MapShiftFromBottom;

        public GameState(Map map, GameSettings settings)
        {
            IsGameEnd = false;
            GetPoints = 0;
            this.mode = settings.GetMode();
            Map = map;

            sw = new Stopwatch();
        }

        public Map Map { get; }

        public Note MakeMove(int keyNumber)
        {
            if (isFirstMove)
            {
                PrimaryPreparation();
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
            IsGameEnd = mode.UpdateIsGameEnd(true, sw.ElapsedMilliseconds, isFirstMove);
            mode.UpdateTimerTick(isFirstMove);
        }

        private void PrimaryPreparation()
        {
            sw.Start();
        }

        public long GetTime => mode.GetTime(sw.ElapsedMilliseconds);
        private void Update(bool isPressNote)
        {
            IsGameEnd = mode.UpdateIsGameEnd(isPressNote, sw.ElapsedMilliseconds, isFirstMove);
            if (IsGameEnd)
            {
                sw.Stop();
            }
            else
            {
                GetPoints = mode.UpdatePoints(sw.ElapsedMilliseconds, GetPoints);
                mode.Update();
            }
        }
    }
}