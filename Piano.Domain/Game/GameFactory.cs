using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GameFactory
    {
        private GameState game;
        //private readonly MapSettings mapSettings;
        //private readonly LoaderSettings gameSettings;
        //private readonly IMapChange mapChange;
        //private readonly ModeSettings modeSettings;
        //private readonly ILoaderChanger loaderChanger;
        //private readonly IModeChanger modeChanger;
        //private readonly KeySettings keySettings;

        //public GameFactory(MapSettings mapSettings, LoaderSettings gameSettings,
        //    IMapChange mapChange, ModeSettings modeSettings, ILoaderChanger loaderChanger,
        //    IModeChanger modeChanger, KeySettings keySettings)
        //{
        //    this.mapSettings = mapSettings;
        //    this.gameSettings = gameSettings;
        //    this.mapChange = mapChange;
        //    this.modeSettings = modeSettings;
        //    this.loaderChanger = loaderChanger;
        //    this.modeChanger = modeChanger;
        //    this.keySettings = keySettings;
        //}

        public GameState CreateGame(MapSettings mapSettings, LoaderSettings gameSettings,
            IMapChange mapChange, ModeSettings modeSettings, ILoaderChanger loaderChanger,
            IModeChanger modeChanger, KeySettings keySettings)
        {
            var map = new Map(mapSettings, gameSettings, mapChange, loaderChanger);
            game = new GameState(map, modeSettings, modeChanger, keySettings);
            return game;
        }

        public GameState GetGame()
        {
            return game;
        }
        public void EndGame()
        {
            game = null;
        }
    }
}
