using CheckersGame.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckersGame.Boards
{
    public class PolishBoard : Board
    {
        #region Constructor
        public PolishBoard()
        {
            SquareSize = 6;
            Letters = ListLetter();
            Squares = new IPiece[SquareSize, SquareSize];

            // Piezas blancas
            Pawn pawnWhite = new Pawn(true);
            Squares[4, 1] = pawnWhite;
            Squares[4, 3] = pawnWhite;
            Squares[4, 5] = pawnWhite;
            Squares[5, 0] = pawnWhite;
            Squares[5, 2] = pawnWhite;
            Squares[5, 4] = pawnWhite;

            // Piezas rojas
            Pawn pawnRed = new Pawn(false);
            Squares[0, 1] = pawnRed;
            Squares[0, 3] = pawnRed;
            Squares[0, 5] = pawnRed;
            Squares[1, 0] = pawnRed;
            Squares[1, 2] = pawnRed;
            Squares[1, 4] = pawnRed;
        }
        #endregion
    }
}
