using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    class GameFactory
    {
        private GameState game;
        public GameState CreateGame(MapSettings mapSettings, LoaderSettings gameSettings, 
            IMapChange mapChange, ModeSettings modeSettings, ILoaderChanger loaderChanger, IModeChanger modeChanger)
        {
            var map = new Map(mapSettings, gameSettings, mapChange, loaderChanger);
            game = new GameState(map, modeSettings, modeChanger);
            return game;
        }

        public GameState Loader() => game;
    }
}
