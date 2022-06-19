using CheckersGame;
using CheckersGame.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCheckersGame.Stub
{
    internal class PieceStub : IPiece
    {
        public bool IsWhite { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<int[]> CapturedPieces { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int GetDirecction()
        {
            throw new NotImplementedException();
        }

        public bool IsValidMove(Board board, int[] start, int[] to)
        {
            throw new NotImplementedException();
        }

        public int NegativeOrPositiveNumbers(int number)
        {
            throw new NotImplementedException();
        }

        public int[] PiecesCapturedByMovement(Board gameBoard, int[] start, int[] to, int[] direction, int[] capturedPiece = null)
        {
            throw new NotImplementedException();
        }
    }
}
