using System;
using System.Collections.Generic;
using System.Text;

namespace CheckersGame.Pieces
{
    public class King : Piece, IPiece
    {
        #region Constructor
        public King(bool IsWhite) : base(IsWhite)
        {
            this.IsWhite = IsWhite;
            this.Name = "o";
        }
        #endregion

        #region Methods
        public bool IsValidMove(Board board, int[] start, int[] to)
        {
            int[] direction = { to[0] - start[0], to[1] - start[1] };
            direction[0] = NegativeOrPositiveNumbers(direction[0]);
            direction[1] = NegativeOrPositiveNumbers(direction[1]);

            int[] capturedPiece = PiecesCapturedByMovement(board, start, to, direction);

            if (capturedPiece == null)
            {
                return false;
            }
            if (capturedPiece != to)
            {
                CapturedPieces.Add(capturedPiece);
            }
            return true;
        }
                     
        public int[] PiecesCapturedByMovement(Board board, int[] start, int[] to, int[] direction, int[] capturedPiece = null)
        {
            int newCoordinateX = start[1] + direction[1];
            int newCoordinateY = start[0] + direction[0];
            int[] newPosition = { newCoordinateY, newCoordinateX };
            bool isValidPosition = board.IsValidPosition(newPosition);

            if (isValidPosition)
            {
                IPiece piece = board.Squares[newPosition[0], newPosition[1]];
                if (piece != null)
                {
                    if (capturedPiece != null)
                    {
                        return null;
                    }

                    bool isEnemyPiece = (piece.IsWhite != this.IsWhite);
                    if (isEnemyPiece)
                    {
                        capturedPiece = newPosition;
                    }
                }

                if (newPosition[0] == to[0] && newPosition[1] == to[1])
                {
                    if (capturedPiece == null)
                    {
                        capturedPiece = to;
                    }
                    return capturedPiece;
                }
                else
                {
                    capturedPiece = PiecesCapturedByMovement(board, newPosition, to, direction, capturedPiece);
                    return capturedPiece;
                }
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
