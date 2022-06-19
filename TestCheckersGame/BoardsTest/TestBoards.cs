using CheckersGame;
using CheckersGame.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCheckersGame.BoardsTest
{
    internal class TestBoards : Board
    {
        public TestBoards()
        {

        }

        public void CrowningBoard()
        {
            SquareSize = 8;
            Letters = ListLetter();
            Squares = new IPiece[SquareSize, SquareSize];

            Pawn pawnWhite = new Pawn(true);
            Squares[0, 1] = pawnWhite;
        }
        
        public void NotCrowningBoard()
        {
            SquareSize = 8;
            Letters = ListLetter();
            Squares = new IPiece[SquareSize, SquareSize];

            Pawn pawnRed = new Pawn(false);
            Squares[0, 1] = pawnRed;
        }
    }
}
