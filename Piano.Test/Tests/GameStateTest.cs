using Domain;
using NUnit.Framework;
using Moq;
using Domain.Infrastructure;

namespace Piano.Test
{
    [TestFixture]
    public class GameStateTest
    {
        private GameState game;
        private int height;

        [SetUp]
        public void SetUp()
        {
            var loaderChanger = new Mock<ILoaderChanger>();
            var modeChanger = new Mock<IModeChanger>();
            var locationChanger = new Mock<ILocationChanger>();
            var melodyChanger = new Mock<IMelodyLoader>();
            melodyChanger.Setup(r => r.Load()).Returns(new Melody(new[] {Note.C}));
            var loaderSettings = new Mock<ILoaderSettings>();
            loaderSettings.Setup(r => r.GetLoader()).Returns(melodyChanger.Object);
            var map = new Map(new MapSettings(), loaderSettings.Object, 
                new TestMapChange(), loaderChanger.Object, locationChanger.Object);
            var modeSettings = new Mock<IModeSettings>();
            modeSettings.Setup(r => r.GetMode()).Returns(new ArcadeMode(map));
            height = 100;
            game = new GameState(map, modeSettings.Object, modeChanger.Object, height);
        }

        [Test]
        public void MakeFirstMove()
        {
            game.MakeMove(0);
            Assert.IsFalse(game.IsGameEnd);
            Assert.AreEqual(1, game.GetPoints);
            Assert.AreEqual(height, game.MapShiftFromBottom);
        }

        [Test]
        public void MakeMoreMove()
        {
            game.MakeMove(0);
            game.MakeMove(0);
            game.MakeMove(0);
            Assert.IsFalse(game.IsGameEnd);
            Assert.AreEqual(3, game.GetPoints);
            Assert.AreEqual(height * 3, game.MapShiftFromBottom);
        }

        [Test]
        public void MakeEndMove()
        {
            game.MakeMove(0);
            game.MakeMove(0);
            game.MakeMove(2);
            Assert.IsTrue(game.IsGameEnd);
            Assert.AreEqual(2, game.GetPoints);
            Assert.AreEqual(height * 2, game.MapShiftFromBottom);
        }
    }
}