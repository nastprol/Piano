using NUnit.Framework;
using Piano;

namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class GameStateTest
    {
        [Test]
        public void MakeFirstMove()
        {
            var melody = new Melody(new[] { Note.C, Note.A });
            var mapCh = new TestMapChange();
            var gameSettings = new GameSettings();
            var settingsForm = new SettingsForm(gameSettings, new LoadConfig());
            var keySettings = new KeySettings();
            var loaderSettings = new LoaderSettings(new[] { new StandardMelodyLoader(settingsForm, gameSettings) }, gameSettings);
            var map = new Map(new MapSettings(), loaderSettings, new TestMapChange(), settingsForm);
            var game = new GameState(map, new ModeSettings(new[] { new ArcadeMode(map) }, gameSettings),
                settingsForm, keySettings);
            game.MakeMove(0);
            Assert.IsFalse(game.IsGameEnd);
            Assert.AreEqual(1,game.GetPoints);
            Assert.AreEqual(keySettings.Height, game.MapShiftFromBottom);
            //Assert.IsTrue(game.GetTime > 0);
        }

        [Test]
        public void MakeMoreMove()
        {
            var melody = new Melody(new[] { Note.C, Note.A });
            var mapCh = new TestMapChange();
            var gameSettings = new GameSettings();
            var settingsForm = new SettingsForm(gameSettings, new LoadConfig());
            var keySettings = new KeySettings();
            var loaderSettings = new LoaderSettings(new[] { new StandardMelodyLoader(settingsForm, gameSettings) }, gameSettings);
            var map = new Map(new MapSettings(), loaderSettings, new TestMapChange(), settingsForm);
            var game = new GameState(map, new ModeSettings(new[] { new ArcadeMode(map) }, gameSettings),
                settingsForm, keySettings);
            game.MakeMove(0);
            game.MakeMove(0);
            game.MakeMove(0);
            Assert.IsFalse(game.IsGameEnd);
            Assert.AreEqual(3,game.GetPoints);
            Assert.AreEqual(keySettings.Height*3,game.MapShiftFromBottom);
        }

        [Test]
        public void MakeEndMove()
        {
            var melody = new Melody(new[] { Note.C, Note.A });
            var mapCh = new TestMapChange();
            var gameSettings = new GameSettings();
            var settingsForm = new SettingsForm(gameSettings, new LoadConfig());
            var keySettings = new KeySettings();
            var loaderSettings = new LoaderSettings(new[] { new StandardMelodyLoader(settingsForm, gameSettings) }, gameSettings);
            var map = new Map(new MapSettings(), loaderSettings, new TestMapChange(), settingsForm);
            var game = new GameState(map, new ModeSettings(new[] { new ArcadeMode(map) }, gameSettings),
                settingsForm, keySettings);
            game.MakeMove(0);
            game.MakeMove(0);
            game.MakeMove(2);
            Assert.IsTrue(game.IsGameEnd);
            Assert.AreEqual( 2,game.GetPoints);
            Assert.AreEqual(keySettings.Height * 2,game.MapShiftFromBottom);
        }


            //[test]
            //public void limitendclassicmode()
            //{
            //    timespan interval = new timespan(0, 1, 0);
            //    var game = new gamestate(new classicmode(), new testmapchange(), new melody(new note[] { note.c, note.a }), 3, 4);
            //    game.makemove(0);
            //    thread.sleep(interval);
            //    assert.catch< exception > (() => game.makemove(0));
            //    assert.isfalse(game.isgameend);
            //    assert.areequal(game.getpoints, 3);


            //} }
        }
}

