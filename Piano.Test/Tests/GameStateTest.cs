//using NUnit.Framework;
//using Piano;

//namespace Prime.UnitTests.Services
//{
//    [TestFixture]
//    public class GameStateTest
//    {
//        [Test]
//        public void MakeFirstMove()
//        {
//            var melody = new Melody(new[] { Note.C, Note.A });
//            var mapCh = new TestMapChange();
//            var map = new Map(new MapSettings(), melody, mapCh);
//            var game = new GameState(map, new GameSettings());
//            game.MakeMove(0);
//            Assert.IsFalse(game.IsGameEnd);
//            Assert.AreEqual(game.GetPoints, 1);
//            Assert.IsTrue(game.GetTime > 0);
//        }

//        [Test]
//        public void MakeMoreMoveClassicMode()
//        {
//            var melody = new Melody(new[] { Note.C, Note.A });
//            var mapCh = new TestMapChange();
//            var map = new Map(new MapSettings(), melody, mapCh);
//            var game = new GameState(new ClassicMode(map), map);
//            game.MakeMove(0);
//            game.MakeMove(0);
//            game.MakeMove(0);
//            Assert.IsFalse(game.IsGameEnd);
//            Assert.AreEqual(game.GetPoints, 3);
//        }

//        [Test]
//        public void MakeEndMove()
//        {
//            var melody = new Melody(new Note[] { Note.C, Note.A });
//            var mapCh = new TestMapChange();
//            var map = new Map(new MapSettings(), melody, mapCh);
//            var game = new GameState(new ClassicMode(map, mapCh, melody), melody, map);
//            game.MakeMove(0);
//            game.MakeMove(0);
//            Assert.Catch<Exception>(() => game.MakeMove(2));
//            Assert.IsTrue(game.IsGameEnd);
//            Assert.AreEqual(game.GetPoints, 2);
//            Assert.IsTrue(game.GetTime > 0);
//        }

//        [Test]
//        public void LimitEndClassicMode()
//        {
//            TimeSpan interval = new TimeSpan(0, 1, 0);
//            var game = new GameState(new ClassicMode(), new TestMapChange(), new Melody(new Note[] { Note.C, Note.A }), 3, 4);
//            game.MakeMove(0);
//            Thread.Sleep(interval);
//            Assert.Catch<Exception>(() => game.MakeMove(0));
//            Assert.IsFalse(game.IsGameEnd);
//            Assert.AreEqual(game.GetPoints, 3);

//        }
//    }
//}

