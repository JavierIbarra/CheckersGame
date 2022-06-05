using System;
using System.Collections.Generic;
using System.Text;

namespace CheckersGame.Pieces
{
    public abstract class Piece
    {
        #region Fields
        private List<int[]> capturedPieces = new List<int[]>();
        #endregion

        #region Properties
        public bool IsWhite { get; set; }
        public string Name { get; set; }
        public List<int[]> CapturedPieces
        {
            get { return capturedPieces; }
            set { capturedPieces = value; }
        }
        #endregion

        #region Constructor
        public Piece(bool IsWhite)
        {
            this.Name = "";
            this.IsWhite = IsWhite;
        }
        #endregion

        #region Method
        public int GetDirecction()
        {
            int upBoard = 1;
            int downBoard = -1;

            if (IsWhite)
            {
                return downBoard;
            }
            else
            {
                return upBoard;
            }
        }

        public abstract bool IsValidMove(Board board, int[] start, int[] to);

        public int NegativeOrPositiveNumbers(int number)
        {
            if (number < 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        #endregion
    }
}
