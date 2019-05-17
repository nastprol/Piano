﻿using System;
using System.Diagnostics;
using System.Linq;
using Piano.Game.State;

namespace Piano
{
    public class ClassicMode : IGameMode
    {
        private readonly Map map;
        private readonly IMapChange mapChange;
        private readonly Melody melody;
        private int points;
        private Stopwatch timer;
        private int limit = 60000;

        public ClassicMode(Map map, IMapChange mapChange, Melody melody)
        {
            this.map = map;
            this.mapChange = mapChange;
            this.melody = melody;
            timer = new Stopwatch();
            points = 0;
        }

        public int GetPoints() => points;

        public long GetTime() => limit - timer.ElapsedMilliseconds;

        public bool IsGameEnd() => timer.ElapsedMilliseconds >= limit;

        public void PrimaryPreparation()
        {
            timer.Start();
        }

        public void AddGame(IGame game)
        {
            return;
        }

        public void Update(bool isGameEnd, int index)
        {
            if (isGameEnd)
                timer.Stop();
            else
            {
                points++;
                var nextNote = melody.Notes.ElementAt(index);
                map.SetNextKeyLine(mapChange.GetNextKeyLine(map.NumberInWidth, nextNote));
            }
        }

        public void MapUpdate(int index)
        {
            
        }

    }
}
