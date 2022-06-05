using CheckersGame;
using CheckersGame.Pieces;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestCheckersGame
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestBoard()
        {
            Board board = new Board();
            board.American();

            Piece[,] expectedOutput = new Piece[,] {
                {null           , new Pawn(false) , null           , new Pawn(false) , null           , new Pawn(false) , null           , new Pawn(false) },
                {new Pawn(false) , null           , new Pawn(false) , null           , new Pawn(false) , null           , new Pawn(false) , null           },
                {null           , new Pawn(false) , null           , new Pawn(false) , null           , new Pawn(false) , null           , new Pawn(false) },
                {null           , null           , null           , null           , null           , null           , null           , null           },
                {null           , null           , null           , null           , null           , null           , null           , null           },
                {new Pawn(true)  , null           , new Pawn(true)  , null           , new Pawn(true)  , null           , new Pawn(true)  , null           },
                {null           , new Pawn(true)  , null           , new Pawn(true)  , null           , new Pawn(true)  , null           , new Pawn(true)  },
                {new Pawn(true)  , null           , new Pawn(true)  , null           , new Pawn(true)  , null           , new Pawn(true)  , null           }
            };


            CompareBoard(expectedOutput, board);
        }

        [Test]
        public void TestCoordinateInput()
        {
            Game game = new Game();
            int[] a1 = game.TranslateCoordinates("A1");
            int[] b2 = game.TranslateCoordinates("B2");
            int[] c3 = game.TranslateCoordinates("C3");
            int[] d4 = game.TranslateCoordinates("D4");
            int[] e5 = game.TranslateCoordinates("E5");
            int[] f6 = game.TranslateCoordinates("F6");
            int[] g7 = game.TranslateCoordinates("G7");
            int[] h8 = game.TranslateCoordinates("H8");

            int[] expectedA1 = new int[2] { 0, 0 };
            int[] expectedB2 = new int[2] { 1, 1 };
            int[] expectedC3 = new int[2] { 2, 2 };
            int[] expectedD4 = new int[2] { 3, 3 };
            int[] expectedE5 = new int[2] { 4, 4 };
            int[] expectedF6 = new int[2] { 5, 5 };
            int[] expectedG7 = new int[2] { 6, 6 };
            int[] expectedH8 = new int[2] { 7, 7 };

            Assert.AreEqual(expectedA1, a1);
            Assert.AreEqual(expectedB2, b2);
            Assert.AreEqual(expectedC3, c3);
            Assert.AreEqual(expectedD4, d4);
            Assert.AreEqual(expectedE5, e5);
            Assert.AreEqual(expectedF6, f6);
            Assert.AreEqual(expectedG7, g7);
            Assert.AreEqual(expectedH8, h8);
        }

        [Test]
        public void TestJump()
        {
            int[] start;
            int[] to;
            int[,] map = {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            };
            int[,] expectedMap = {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            };

            Game game = new Game(10);
            game.CreateBoard(map);

            Game expectedGame = new Game(10);
            expectedGame.CreateBoard(expectedMap);

            start = game.TranslateCoordinates("H3");
            to = game.TranslateCoordinates("F5");
            game.MovePiece(start, to);

            CompareBoard(expectedGame.GameBoard.Squares, game.GameBoard);
        }


        [Test]
        public void TestSimpleMove()
        {
            int[,] map = {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            };
            int[,] expectedMap = {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            };
            int size = 10;
            Game game = new Game(size);
            game.CreateBoard(map);

            Game expectedGame = new Game(size);
            expectedGame.CreateBoard(expectedMap);

            int[] start = game.TranslateCoordinates("H3");
            int[] to = game.TranslateCoordinates("G4");
            game.MovePiece(start, to);

            start = game.TranslateCoordinates("G4");
            to = game.TranslateCoordinates("F3");
            game.MovePiece(start, to);

            CompareBoard(expectedGame.GameBoard.Squares, game.GameBoard);
        }
        
        public void CompareBoard(Piece[,] expected, Board actual)
        {
            for (int x = 0; x < expected.GetLength(0); x += 1)
            {
                for (int y = 0; y < expected.GetLength(1); y += 1)
                {
                    if (expected[x, y] != null)
                    {
                        Assert.AreEqual(expected[x, y].Name, actual.Squares[x, y].Name);
                        Assert.AreEqual(expected[x, y].IsWhite, actual.Squares[x, y].IsWhite);
                    }
                }
            }
        }
    }
}