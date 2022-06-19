using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Text;
using CheckersGame;
using CheckersGame.Boards;

namespace TestCheckersGame.BoardsTest
{
    internal class BoardTest
    {
        private Board _board;

        [SetUp]
        public void Setup()
        {
            _board = new PolishBoard();
        }

        [Test]
        public void CanPieceMoveFalseTest()
        {
            bool expected = false;
            int[] coordinate =  { 0, 1 };
            bool actual = _board.CanPieceMove(coordinate);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanPieceMoveTrueTest()
        {
            bool expected = true;
            int[] coordinate = { 1, 0 };
            bool actual = _board.CanPieceMove(coordinate);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ValidPositionTest()
        {
            int[] coordinate = { 5, 5 };
            bool actual = _board.IsValidPosition(coordinate);

            Assert.IsTrue(actual);
        }

        [Test]
        public void InvalidPositionTest()
        {
            int[] coordinate = { -1, 0 };
            bool actual = _board.IsValidPosition(coordinate);

            Assert.IsFalse(actual);

            coordinate = new int[] { 0, -1 };
            actual = _board.IsValidPosition(coordinate);

            Assert.IsFalse(actual);

            coordinate = new int[] { 7, 0 };
            actual = _board.IsValidPosition(coordinate);

            Assert.IsFalse(actual);

            coordinate = new int[] { 0, 7 };
            actual = _board.IsValidPosition(coordinate);

            Assert.IsFalse(actual);
        }

        [Test]
        public void ListLetterTest()
        {
            int sizeAmericanBoard = 8;
            int sizeInternationalBoard = 10;
            int sizePolishBoard = 6;

            Board americanBoard = new AmericanBoard();
            List<char> letters = americanBoard.ListLetter();

            Assert.AreEqual(americanBoard.SquareSize, letters.Count);
            Assert.AreEqual(sizeAmericanBoard, letters.Count);

            Board internationalBoard = new InternationalBoard();
            letters = internationalBoard.ListLetter();

            Assert.AreEqual(internationalBoard.SquareSize, letters.Count);
            Assert.AreEqual(sizeInternationalBoard, letters.Count);

            Board polishBoard = new PolishBoard();
            letters = polishBoard.ListLetter();

            Assert.AreEqual(polishBoard.SquareSize, letters.Count);
            Assert.AreEqual(sizePolishBoard, letters.Count);
        }

        [Test]
        public void CrowningTest()
        {
            string expected = "o";
            TestBoards board = new TestBoards();
            board.CrowningBoard();

            board.Crowning();

            Assert.AreEqual(expected, board.Squares[0, 1].Name); 
        }

        [Test]
        public void NotCrowningTest()
        {
            string expected = "x";
            TestBoards board = new TestBoards();
            board.NotCrowningBoard();

            board.Crowning();

            Assert.AreEqual(expected, board.Squares[0, 1].Name);
        }
    }
}
