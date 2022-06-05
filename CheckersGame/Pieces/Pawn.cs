using System;
using System.Collections.Generic;
using System.Text;

namespace CheckersGame.Pieces
{
    public class Pawn : Piece
    {
        #region Constructor
        public Pawn(bool IsWhite) : base(IsWhite)
        {
            this.IsWhite = IsWhite;
            this.Name = "x";
        }
        #endregion

        #region Methods
        public override bool IsValidMove(Board gameBoard, int[] start, int[] to)
        {
            int direction = to[1] - start[1];
            direction = NegativeOrPositiveNumbers(direction);

            int[] capturedPiece = PiecesCapturedByMovement(gameBoard, start, to, direction);

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

        private int[] PiecesCapturedByMovement(Board gameBoard, int[] start, int[] to, int direction, int[] capturedPiece = null)
        {
            int newCoordinateX = start[1] + direction;
            int newCoordinateY = start[0] + GetDirecction();
            int[] newPosition = { newCoordinateY, newCoordinateX };
            bool isValidPosition = gameBoard.IsValidPosition(newPosition);

            if (isValidPosition)
            {
                Piece piece = gameBoard.Squares[newPosition[0], newPosition[1]];
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
                    return PiecesCapturedByMovement(gameBoard, newPosition, to, direction, capturedPiece);

                }
                if (newPosition[0] == to[0] && newPosition[1] == to[1])
                {
                    if (capturedPiece == null)
                    {
                        capturedPiece = to;
                    }
                    
                    return capturedPiece;
                }
            }
            return null;
        }
        #endregion
    }
}
