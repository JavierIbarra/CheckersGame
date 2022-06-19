using System;
using System.Collections.Generic;
using System.Text;

namespace CheckersGame.Pieces
{
    public interface IPiece
    {
        public bool IsWhite { get; set; }
        public string Name { get; set; }
        public List<int[]> CapturedPieces { get; set; }

        public int GetDirecction();
        public int NegativeOrPositiveNumbers(int number);
        public bool IsValidMove(Board board, int[] start, int[] to);
        public int[] PiecesCapturedByMovement(Board gameBoard, int[] start, int[] to, int[] direction, int[] capturedPiece = null);

    }
}
