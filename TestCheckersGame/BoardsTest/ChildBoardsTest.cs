using CheckersGame;
using CheckersGame.Boards;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCheckersGame.BoardsTest
{
    internal class ChildBoardsTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAmericanBoard()
        {
            int expected = 8;
            Board board = new AmericanBoard();

            Assert.AreEqual(expected, board.SquareSize);
        }

        [Test]
        public void TestInternationalBoard()
        {
            int expected = 10;
            Board board = new InternationalBoard();

            Assert.AreEqual(expected, board.SquareSize);
        }

        [Test]
        public void TestPolishBoard()
        {
            int expected = 6;
            Board board = new PolishBoard();

            Assert.AreEqual(expected, board.SquareSize);
        }
    }
}
