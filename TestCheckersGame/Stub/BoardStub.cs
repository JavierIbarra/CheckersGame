using CheckersGame.Boards;
using CheckersGame.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCheckersGame.Stub
{
    internal class BoardStub : IBoard
    {
        public IPiece[,] Squares { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool CanPieceMove(int[] start)
        {
            throw new NotImplementedException();
        }

        public void Crowning()
        {
            throw new NotImplementedException();
        }

        public bool IsValidPosition(int[] Position)
        {
            throw new NotImplementedException();
        }

        public List<char> ListLetter()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }
    }
}
