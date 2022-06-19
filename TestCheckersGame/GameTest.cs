using CheckersGame;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestCheckersGame
{
    internal class GameTest
    {
        [Test]
        public void CreateBoard()
        {
            bool expected = true;
            Game game = new Game();

            Assert.AreEqual(expected, game.IsPlayer1Turn);
        }
    }
}
