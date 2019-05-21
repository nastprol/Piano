using System;
using System.Collections.Generic;
using System.Linq;

namespace Piano
{
    public class Map
    {
        private readonly IMapChange mapChange;
        private readonly int melodyLength;
        private int index;
        
        public Melody Melody { get; }
        private List<Note> notes;

        public Map(MapSettings settings, Melody melody, IMapChange mapChange)
        {
            Height = settings.Height;
            Width = settings.Width;
            index = -1;
            this.mapChange = mapChange;
            melodyLength = melody.Count;
            notes = melody.ToList();

            keys = new PianoKey[Height, Width];
            Melody = melody;           
            for (var i = 0; i < Height; i++)
            {
                MapUpdate();
            }
        }

        public int Width { get; }
        public int Height { get; }
        private PianoKey[,] keys; 
       
        public PianoKey this[int i, int j]
        {
            get => keys[i, j];
            set => keys[i, j] = value;
        }

        public void SetNextKeyLine(PianoKey[] keyLine)
        {
            if (keyLine.Length != Width)
                throw new Exception();   //не используй чистый Exception пиши более конкретный(можешь свой создать) и пиши в нём сообщение об ошибке
            for (var i = 0; i < Height - 1; i++)
            for (var j = 0; j < Width; j++)
                keys[i, j] = keys[i + 1, j];
            for (var j = 0; j < Width; j++)
                keys[Height - 1, j] = keyLine[j];
        }

        public PianoKey[] GetFirstLine()
        {
            var lastLine = new PianoKey[Width];
            for (var j = 0; j < Width; j++)
                lastLine[j] = keys[0, j];
            return lastLine;
        }

        public bool IsFirstLineWithoutNote()
        {
            for (var j = 0; j < Width; j++)
                if (keys[0, j].IsNote)
                    return false;
            return true;
        }

        public void MapUpdate()
        {
            index = index + 1 < melodyLength ? index + 1 : 0;
            var nextNote = notes[index]; 
            SetNextKeyLine(mapChange.GetNextKeyLine(Width, nextNote));
        }
    }
}