using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    interface IGameFactory
    {
        GameState Loader();
        GameState CreateGame(MapSettings mapSettings, LoaderSettings gameSettings,
            IMapChange mapChange, ModeSettings modeSettings, ILoaderChanger loaderChanger,
            IModeChanger modeChanger, KeySettings keySettings);
    }
}
