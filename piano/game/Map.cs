using System;
using System.Linq;

namespace Piano
{
    public class Map
    {
        private readonly IMapChange mapChange;
        private readonly int melodyLength;
        private int index;
        private int mapShiftFromBottom;

        public Map(MapSettings settings, Melody melody, IMapChange mapChange)
        {
            Height = settings.Height;
            Width = settings.Width;
            index = Height;
            this.mapChange = mapChange;
            melodyLength = melody.Notes.Count(); // Count - долгая операция, как исправить написал в Melody

            Keys = new PianoKey[Height, Width];
            Melody = melody;

            //-------------------------------------------------------------------------------------//
            for (var i = 0; i < Height; i++)
            for (var j = 0; j < Width; j++)
                Keys[i, j] = new PianoKey();
            var elementIndex = 0;
            for (var i = 0; i < Height; i++)
            {
                var note = Melody.Notes.ElementAt(elementIndex);
                elementIndex = elementIndex + 1 < Melody.Notes.Count() ? elementIndex + 1 : 0;
                SetNextKeyLine(mapChange.GetNextKeyLine(Width, note));
            }
            //------------------------------------------------------------------------------------// этот код очень похож на код в методе SetNextKeyLine, наверное стоит попытаться вынести в метод)
        }

        public int Width { get; }
        public int Height { get; }
        public PianoKey[,] Keys { get; }  // нарушена инкапсуляция!!!
        public Melody Melody { get; }

        public PianoKey this[int i, int j]
        {
            get => Keys[i, j];
            set => Keys[i, j] = value;
        }

        public void SetNextKeyLine(PianoKey[] keyLine)
        {
            if (keyLine.Length != Width)
                throw new Exception();   //не используй чистый Exception пиши более конкретный(можешь свой создать) и пиши в нём сообщение об ошибке
            for (var i = 0; i < Height - 1; i++)
            for (var j = 0; j < Width; j++)
                Keys[i, j] = Keys[i + 1, j];
            for (var j = 0; j < Width; j++)
                Keys[Height - 1, j] = keyLine[j];
        }

        public PianoKey[] GetFirstLine()
        {
            var lastLine = new PianoKey[Width];
            for (var j = 0; j < Width; j++)
                lastLine[j] = Keys[0, j];
            return lastLine;
        }

        public void MapUpdate()
        {
            index = index + 1 < melodyLength ? index + 1 : 0;
            var nextNote = Melody.Notes.ElementAt(index); // ElementAt - долгая операция, как исправить написал в Melody
            SetNextKeyLine(mapChange.GetNextKeyLine(Width, nextNote));
        }
    }
}