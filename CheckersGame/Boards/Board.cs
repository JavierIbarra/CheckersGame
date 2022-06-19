using CheckersGame.Boards;
using CheckersGame.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckersGame
{
    public class Board : IBoard
    {
        #region Properties
        public int SquareSize { get; protected set; }
        public IPiece[,] Squares { get; set; }
        protected List<char> Letters { get;  set; }
        #endregion

        #region Methods
        public bool CanPieceMove(int[] start)
        {
            int spaceToReview = 2;
            IPiece piece = Squares[start[0], start[1]];

            if (piece == null)
            {
                return true;
            }

            for (int column = -spaceToReview; column < spaceToReview; column++)
            {
                for (int row = -spaceToReview; row < spaceToReview; row++)
                {
                    int[] newPositionPiece = { start[0] + column, start[1] + row };
                    if (piece.IsValidMove(this, start, newPositionPiece))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void Crowning()
        {
            for (int row = 0; row < Squares.GetLength(0); row += 1)
            {
                if (Squares[0, row] != null)
                {
                    bool isWhite = Squares[0, row].IsWhite;
                    if (isWhite)
                    {
                        Squares[0, row] = new King(isWhite);
                    }
                }

                int longBoard = SquareSize - 1;

                if (Squares[longBoard, row] != null)
                {
                    bool isWhite = Squares[longBoard, row].IsWhite;
                    if (!isWhite)
                    {
                        Squares[longBoard, row] = new King(isWhite);
                    }
                }
            }
        }

        public bool IsValidPosition(int[] Position)
        {
            bool isValidPositionX = ((Position[1] < SquareSize) && (Position[1] >= 0));
            bool isValidPositionY = (((Position[0] < SquareSize) && (Position[0] >= 0)));
            bool isValidPosition = (isValidPositionX && isValidPositionY);

            return isValidPosition;
        }

        public void Show()
        {
            string rows = " ";

            foreach (char letter in Letters)
            {
                int columnNumber = Letters.IndexOf(letter) + 1;
                rows += "  " + columnNumber + "  ";
            }
            Console.WriteLine("\n" + rows);

            int countColumns = 0;
            Console.Write(Letters[countColumns]);
            foreach (Piece piece in Squares)
            {
                string namePiece;
                ConsoleColor colorPiece = ConsoleColor.White;
                int countRow = countColumns / SquareSize;
                bool isNewColumn = (countColumns % SquareSize == 0 && countColumns != 0);

                if (isNewColumn)
                {
                    Console.WriteLine();
                    Console.Write(Letters[countRow]);
                }

                if (piece != null)
                {
                    namePiece = piece.Name;
                    if (piece.IsWhite)
                    {
                        colorPiece = ConsoleColor.White;
                    }
                    else
                    {
                        colorPiece = ConsoleColor.Red;
                    }
                }
                else
                {
                    namePiece = " ";
                }

                bool isEvenColumn = (countColumns % 2 == 0);
                bool isEvenRow = (countRow % 2 == 0);

                if ((!isEvenColumn && isEvenRow) || (isEvenColumn && !isEvenRow))
                {
                    WriteColor(" (", ConsoleColor.Green);
                    WriteColor(namePiece, colorPiece);
                    WriteColor(") ", ConsoleColor.Green);
                }
                else
                {
                    WriteColor(" [ ] ", ConsoleColor.Yellow);
                }
                countColumns++;
            }
        }

        public List<char> ListLetter()
        {
            List<char> Letters = new List<char>();
            char letterEnd = (char)('A' + SquareSize);
            for (char letter = 'A'; letter < letterEnd; letter++)
            {
                Letters.Add(letter);
            }
            return Letters;
        }

        private void WriteColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
        #endregion
    }
}
