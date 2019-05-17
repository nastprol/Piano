using NUnit.Framework;
using Piano;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class GameStateTest
    {
        [Test]
        public void MakeFirstMove()
        {
            var melody = new Melody(new Note[] {Note.Do, Note.La});
            var mapCh = new TestMapChange();
            var map = new Map(new MapSettings(), melody, mapCh);
            var game = new GameState(new ClassicMode(map, mapCh, melody), melody, map);
            game.MakeMove(0);
            Assert.IsFalse(game.IsGameEnd);
            Assert.AreEqual(game.GetPoints, 1);
            Assert.IsTrue(game.GetTime > 0);

        }

        [Test]
        public void MakeMoreMove()
        {
            var melody = new Melody(new Note[] { Note.Do, Note.La });
            var mapCh = new TestMapChange();
            var map = new Map(new MapSettings(), melody, mapCh);
            var game = new GameState(new ClassicMode(map, mapCh, melody), melody, map);
            game.MakeMove(0);
            game.MakeMove(0);
            game.MakeMove(0);
            Assert.IsFalse(game.IsGameEnd);
            Assert.AreEqual(game.GetPoints, 3);
            Assert.IsTrue(game.GetTime > 0);

        }

        [Test]
        public void MakeEndMove()
        {
            var melody = new Melody(new Note[] { Note.Do, Note.La });
            var mapCh = new TestMapChange();
            var map = new Map(new MapSettings(), melody, mapCh);
            var game = new GameState(new ClassicMode(map, mapCh, melody), melody, map);
            game.MakeMove(0);
            game.MakeMove(0);
            Assert.Catch<Exception>(() => game.MakeMove(2));
            Assert.IsTrue(game.IsGameEnd);
            Assert.AreEqual(game.GetPoints, 2);
            Assert.IsTrue(game.GetTime > 0);
        }


    }
}
