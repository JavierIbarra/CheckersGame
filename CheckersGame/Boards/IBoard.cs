using CheckersGame.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckersGame.Boards
{
    public interface IBoard
    { 
        public int SquareSize { get; }
        public IPiece[,] Squares { get; set; }

        public bool CanPieceMove(int[] start);

        public void Crowning();

        public bool IsValidPosition(int[] Position);

        public void Show();

        public List<char> ListLetter();

    }
}
