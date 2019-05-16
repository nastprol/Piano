using NUnit.Framework;
using Piano;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class GameStateTest
    {
        [Test]
        public void MakeFirstMove()
        {
            var game = new GameState(new ClassicMode(), new TestMapChange(), new Melody(new Note[] { Note.Do, Note.La }), 3, 4);
            game.MakeMove(0);
            Assert.IsFalse(game.IsGameEnd);
            Assert.AreEqual(game.GetPoints, 1);
            Assert.IsTrue(game.GetTime > 0);

        }

        [Test]
        public void MakeMoreMoveClassicMode()
        {
            var game = new GameState(new ClassicMode(), new TestMapChange(), new Melody(new Note[] { Note.Do, Note.La }), 3, 4);
            game.MakeMove(0);
            game.MakeMove(0);
            game.MakeMove(0);
            Assert.IsFalse(game.IsGameEnd);
            Assert.AreEqual(game.GetPoints, 3);

        }

        [Test]
        public void MakeEndMove()
        {
            var game = new GameState(new ClassicMode(), new TestMapChange(), new Melody(new Note[] { Note.Do, Note.La }), 3, 4);
            game.MakeMove(0);
            game.MakeMove(0);
            Assert.Catch<Exception>(() => game.MakeMove(2));
            Assert.IsTrue(game.IsGameEnd);
            Assert.AreEqual(game.GetPoints, 2);
            Assert.IsTrue(game.GetTime > 0);
        }

        [Test]
        public void LimitEndClassicMode()
        {
            TimeSpan interval = new TimeSpan(0,1,0);
            var game = new GameState(new ClassicMode(), new TestMapChange(), new Melody(new Note[] { Note.Do, Note.La }), 3, 4);
            game.MakeMove(0);
            Thread.Sleep(interval);
            Assert.Catch<Exception>(() => game.MakeMove(0));
            Assert.IsFalse(game.IsGameEnd);
            Assert.AreEqual(game.GetPoints, 3);

        }


    }
}
