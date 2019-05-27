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
        public GameState createGame(MapSettings mapSettings, LoaderSettings gameSettings, IMapChange mapChange, ModeSettings modeSettings)
        {
            var map = new Map(mapSettings, gameSettings, mapChange);
            game = new GameState(map, modeSettings);
            return game;
        }

        public GameState Loader() => game;


    }
}
