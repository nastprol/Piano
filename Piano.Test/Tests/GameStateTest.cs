using Domain;
using App;
using NUnit.Framework;
using Moq;
using System.Windows.Forms;

namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class GameStateTest
    {
        [Test]
        public void MakeFirstMove()
        {
            var mapCh = new TestMapChange();
            Mock<ILoaderChanger> loaderChenger = new Mock<ILoaderChanger>();
            Mock<IModeChanger> modeChenger = new Mock<IModeChanger>();
            Mock<IMelodyLoader> melodyChenger = new Mock<IMelodyLoader>();
            melodyChenger.Setup(r => r.Load()).Returns(new Melody(new[] { Note.C }));
            Mock<ILoaderSettings> loaderSettings = new Mock<ILoaderSettings>();
            loaderSettings.Setup(r => r.GetLoader()).Returns(melodyChenger.Object);            
            var keySettings = new KeySettings();

            var map = new Map(new MapSettings(), loaderSettings.Object, new TestMapChange(), loaderChenger.Object);
            Mock<IModeSettings> modeSettings = new Mock<IModeSettings>();
            modeSettings.Setup(r => r.GetMode()).Returns(new ArcadeMode(map));

            var game = new GameState(map, modeSettings.Object,modeChenger.Object, keySettings);
            game.MakeMove(0);
            Assert.IsFalse(game.IsGameEnd);
            Assert.AreEqual(1, game.GetPoints);
            Assert.AreEqual(keySettings.Height, game.MapShiftFromBottom);
        }

        [Test]
        public void MakeMoreMove()
        {
            var mapCh = new TestMapChange();
            Mock<ILoaderChanger> loaderChenger = new Mock<ILoaderChanger>();
            Mock<IModeChanger> modeChenger = new Mock<IModeChanger>();
            Mock<IMelodyLoader> melodyChenger = new Mock<IMelodyLoader>();
            melodyChenger.Setup(r => r.Load()).Returns(new Melody(new[] { Note.C }));
            Mock<ILoaderSettings> loaderSettings = new Mock<ILoaderSettings>();
            loaderSettings.Setup(r => r.GetLoader()).Returns(melodyChenger.Object);
            var keySettings = new KeySettings();

            var map = new Map(new MapSettings(), loaderSettings.Object, new TestMapChange(), loaderChenger.Object);
            Mock<IModeSettings> modeSettings = new Mock<IModeSettings>();
            modeSettings.Setup(r => r.GetMode()).Returns(new ArcadeMode(map));

            var game = new GameState(map, modeSettings.Object, modeChenger.Object, keySettings);
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
            var mapCh = new TestMapChange();
            Mock<ILoaderChanger> loaderChenger = new Mock<ILoaderChanger>();
            Mock<IModeChanger> modeChenger = new Mock<IModeChanger>();
            Mock<IMelodyLoader> melodyChenger = new Mock<IMelodyLoader>();
            melodyChenger.Setup(r => r.Load()).Returns(new Melody(new[] { Note.C }));
            Mock<ILoaderSettings> loaderSettings = new Mock<ILoaderSettings>();
            loaderSettings.Setup(r => r.GetLoader()).Returns(melodyChenger.Object);
            var keySettings = new KeySettings();

            var map = new Map(new MapSettings(), loaderSettings.Object, new TestMapChange(), loaderChenger.Object);
            Mock<IModeSettings> modeSettings = new Mock<IModeSettings>();
            modeSettings.Setup(r => r.GetMode()).Returns(new ArcadeMode(map));

            var game = new GameState(map, modeSettings.Object, modeChenger.Object, keySettings);
            game.MakeMove(0);
            game.MakeMove(0);
            game.MakeMove(2);
            Assert.IsTrue(game.IsGameEnd);
            Assert.AreEqual(2, game.GetPoints);
            Assert.AreEqual(keySettings.Height * 2, game.MapShiftFromBottom);
        }
    }
}