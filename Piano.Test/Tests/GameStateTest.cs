using Domain;
using NUnit.Framework;
using Moq;


namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class GameStateTest
    {
        private GameState game;
        private KeySettings keySettings;

        [SetUp]
        public void SetUp()
        {
            var loaderChanger = new Mock<ILoaderChanger>();
            var modeChanger = new Mock<IModeChanger>();
            var melodyChanger = new Mock<IMelodyLoader>();
            melodyChanger.Setup(r => r.Load()).Returns(new Melody(new[] {Note.C}));
            var loaderSettings = new Mock<ILoaderSettings>();
            loaderSettings.Setup(r => r.GetLoader()).Returns(melodyChanger.Object);
            keySettings = new KeySettings();
            var map = new Map(new MapSettings(), loaderSettings.Object, new TestMapChange(), loaderChanger.Object);
            var modeSettings = new Mock<IModeSettings>();
            modeSettings.Setup(r => r.GetMode()).Returns(new ArcadeMode(map));
            game = new GameState(map, modeSettings.Object, modeChanger.Object, keySettings);
        }

        [Test]
        public void MakeFirstMove()
        {
            game.MakeMove(0);
            Assert.IsFalse(game.IsGameEnd);
            Assert.AreEqual(1, game.GetPoints);
            Assert.AreEqual(keySettings.Height, game.MapShiftFromBottom);
        }

        [Test]
        public void MakeMoreMove()
        {
            game.MakeMove(0);
            game.MakeMove(0);
            game.MakeMove(0);
            Assert.IsFalse(game.IsGameEnd);
            Assert.AreEqual(3, game.GetPoints);
            Assert.AreEqual(keySettings.Height * 3, game.MapShiftFromBottom);
        }

        [Test]
        public void MakeEndMove()
        {
            game.MakeMove(0);
            game.MakeMove(0);
            game.MakeMove(2);
            Assert.IsTrue(game.IsGameEnd);
            Assert.AreEqual(2, game.GetPoints);
            Assert.AreEqual(keySettings.Height * 2, game.MapShiftFromBottom);
        }
    }
}