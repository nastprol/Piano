namespace Domain
{
    public class GameFactory
    {
        private GameState game;

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
