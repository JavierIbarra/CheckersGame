using CheckersGame.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckersGame.Boards
{
    public class InternationalBoard : Board
    {
        #region Constructor
        public InternationalBoard()
        {
            SquareSize = 10;
            Letters = ListLetter();
            Squares = new IPiece[SquareSize, SquareSize];

            // Piezas blancas
            Pawn pawnWhite = new Pawn(true);
            Squares[6, 1] = pawnWhite;
            Squares[6, 3] = pawnWhite;
            Squares[6, 5] = pawnWhite;
            Squares[6, 7] = pawnWhite;
            Squares[6, 9] = pawnWhite;
            Squares[7, 0] = pawnWhite;
            Squares[7, 2] = pawnWhite;
            Squares[7, 4] = pawnWhite;
            Squares[7, 6] = pawnWhite;
            Squares[7, 8] = pawnWhite;
            Squares[8, 1] = pawnWhite;
            Squares[8, 3] = pawnWhite;
            Squares[8, 5] = pawnWhite;
            Squares[8, 7] = pawnWhite;
            Squares[8, 9] = pawnWhite;
            Squares[9, 0] = pawnWhite;
            Squares[9, 2] = pawnWhite;
            Squares[9, 4] = pawnWhite;
            Squares[9, 6] = pawnWhite;
            Squares[9, 8] = pawnWhite;

            // Piezas rojas
            Pawn pawnRed = new Pawn(false);
            Squares[0, 1] = pawnRed;
            Squares[0, 3] = pawnRed;
            Squares[0, 5] = pawnRed;
            Squares[0, 7] = pawnRed;
            Squares[0, 9] = pawnRed;
            Squares[1, 0] = pawnRed;
            Squares[1, 2] = pawnRed;
            Squares[1, 4] = pawnRed;
            Squares[1, 6] = pawnRed;
            Squares[1, 8] = pawnRed;
            Squares[2, 1] = pawnRed;
            Squares[2, 3] = pawnRed;
            Squares[2, 5] = pawnRed;
            Squares[2, 7] = pawnRed;
            Squares[2, 9] = pawnRed;
            Squares[3, 0] = pawnRed;
            Squares[3, 2] = pawnRed;
            Squares[3, 4] = pawnRed;
            Squares[3, 6] = pawnRed;
            Squares[3, 8] = pawnRed;
        }
        #endregion
    }
}
