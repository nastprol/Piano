using System;

namespace Domain
{
    public class Map
    {
        private readonly PianoKey[,] keys;
        private readonly IMapChange mapChange;
        private int MelodyLength => Melody.Count;
        private int index;
        LoaderSettings loaderSettings;

        public Map(MapSettings settings, LoaderSettings loaderSettings, IMapChange mapChange, ILoaderChanger changer)
        {
            this.loaderSettings = loaderSettings;
            Melody = loaderSettings.GetLoader().Load();
            changer.LoaderChange += Update;
            Height = settings.Height;
            Width = settings.Width;
            index = -1;
            this.mapChange = mapChange;

            keys = new PianoKey[Height, Width];
            for (var i = 0; i < Height; i++)
                MapUpdate();
        }

        private void Update(object sender, EventArgs e)
        {
            Melody = loaderSettings.GetLoader().Load();
        }

        public Melody Melody { private set;  get; }

        public int Width { get; }
        public int Height { get; }

        public PianoKey this[int i, int j]
        {
            get => keys[i, j];
            set => keys[i, j] = value;
        }

        public void SetNextKeyLine(PianoKey[] keyLine)
        {
            if (keyLine.Length != Width)
                throw  new Exception("Wrong format of keyLine"); 
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
            index = index + 1 < MelodyLength ? index + 1 : 0;
            var nextNote = Melody[index];
            SetNextKeyLine(mapChange.GetNextKeyLine(Width, nextNote));
        }
    }
}