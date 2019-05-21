using Piano.Game.State;
using System;

namespace Piano
{
    public class GameState : IGame
    {
        private readonly IModeControl modeControl;
        private bool isFirstMove = true;

        public GameState(IModeControl modeControl, Map map)
        {
            this.modeControl = modeControl;
            Map = map;
        }

        public Map Map { get; }

        public Note MakeMove(int keyNumber)
        {
            if (isFirstMove)
            {
                modeControl.PrimaryPreparation();
                isFirstMove = false;
            }

            var firstLine = Map.GetFirstLine();
            var pianoKey = firstLine[keyNumber];
            var isPressNote = pianoKey.IsNote;
            pianoKey.Press();
            modeControl.Update(isPressNote);
            return pianoKey.Note;
        }

        public void Update()
        {
            
        }

        public int GetPoints => modeControl.Points;

        public long GetTime => modeControl.GetTime();

        public bool IsGameEnd => modeControl.IsGameEnd;
    }
}