using NUnit.Framework;
using Domain;
using Moq;
using System.Windows.Forms;
using Domain.Infrastructure;
using System;

namespace Piano.Test
{
    [TestFixture]
    public class LoaderTest
    {
        private ILocationChanger changer;
        private GameSettings settings;

        [SetUp]
        public void SetUp()
        {
            changer = new Mock<ILocationChanger>().Object;
            settings = new Mock<GameSettings>().Object;
        }

        [Test]
        public void LoadFromFile()
        {
            settings.MelodyLocation = Environment.CurrentDirectory + @"\Piano.Test\Tests\1.txt";
            var loader = new MelodyFileLoader(changer, settings);
            var expected = new Melody(new Note[7] { Note.C, Note.D, Note.E, Note.F, Note.A, Note.B, Note.G });
            var melody = loader.Load();
            Assert.AreEqual(expected, melody);
        }

        [TestCase("2")]
        [TestCase("1")]
        public void LoadStandardMelody(string location)
        {
            settings.MelodyLocation = location;
            var loader = new StandardMelodyLoader(changer, settings);
            var expected = StandardMelodyLoader.StandardMelodies[location];
            var melody = loader.Load();
            Assert.AreEqual(expected, melody);
        }
    }
}