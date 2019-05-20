using System.Collections.Generic;
using NUnit.Framework;
using Piano;

namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class LoaderTest
    {
        [Test]
        public void GetMelodyFromFile()
        {
            var loader = new MelodyFileLoader();
            var melody = loader.Load(new FileLocator("C:\\Users\\Настя\\Desktop\\piano\\1.txt"));
            var expected = new Melody(new List<Note> {Note.Do, Note.Re, Note.Mi, Note.Fa, Note.La, Note.Si, Note.Sol});
            Assert.AreEqual(expected.Notes, melody.Notes);
        }
    }
}