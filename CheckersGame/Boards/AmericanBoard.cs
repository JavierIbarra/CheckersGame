using CheckersGame.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckersGame.Boards
{
    public class AmericanBoard : Board
    {

        #region Constructor
        public AmericanBoard()
        {
            SquareSize = 8;
            Letters = ListLetter();
            Squares = new IPiece[SquareSize, SquareSize];

            // Piezas blancas
            Pawn pawnWhite = new Pawn(true);
            Squares[5, 0] = pawnWhite;
            Squares[5, 2] = pawnWhite;
            Squares[5, 4] = pawnWhite;
            Squares[5, 6] = pawnWhite;
            Squares[6, 1] = pawnWhite;
            Squares[6, 3] = pawnWhite;
            Squares[6, 5] = pawnWhite;
            Squares[6, 7] = pawnWhite;
            Squares[7, 0] = pawnWhite;
            Squares[7, 2] = pawnWhite;
            Squares[7, 4] = pawnWhite;
            Squares[7, 6] = pawnWhite;

            // Piezas rojas
            Pawn pawnRed = new Pawn(false);
            Squares[0, 1] = pawnRed;
            Squares[0, 3] = pawnRed;
            Squares[0, 5] = pawnRed;
            Squares[0, 7] = pawnRed;
            Squares[1, 0] = pawnRed;
            Squares[1, 2] = pawnRed;
            Squares[1, 4] = pawnRed;
            Squares[1, 6] = pawnRed;
            Squares[2, 1] = pawnRed;
            Squares[2, 3] = pawnRed;
            Squares[2, 5] = pawnRed;
            Squares[2, 7] = pawnRed;
        }
        #endregion
    }
}
