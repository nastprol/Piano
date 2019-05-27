using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    class GameFactory:IGameFactory
    {
        private GameState game;
        public GameState CreateGame(MapSettings mapSettings, LoaderSettings gameSettings, IMapChange mapChange, ModeSettings modeSettings, KeySettings keySettings)
        {
            var map = new Map(mapSettings, gameSettings, mapChange);
            game = new GameState(map, modeSettings, keySettings);
            return game;
        }

        public GameState Loader() => game;


    }
}
