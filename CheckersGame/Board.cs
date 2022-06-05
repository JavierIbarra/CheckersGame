using CheckersGame.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckersGame
{
    public class Board
    {
        #region Properties
        public int SquareSize { get; private set; }
        public Piece[,] Squares { get; set; }
        public List<char> Letters { get; private set; }
        #endregion

        #region Constructor
        public Board() { }

        public Board(int Size)
        {
            SquareSize = Size;
            Letters = ListLetter();
            Squares = new Piece[SquareSize, SquareSize];
        }
        #endregion

        #region Methods
        public bool CanPieceMove(int[] start)
        {
            int spaceToReview = 2;
            Piece piece = Squares[start[0], start[1]];

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

        private List<char> ListLetter()
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

        public void International()
        {
            SquareSize = 10;
            Letters = ListLetter();
            Squares = new Piece[SquareSize, SquareSize];

            // Piezas blancas
            Squares[6, 1] = new Pawn(true);
            Squares[6, 3] = new Pawn(true);
            Squares[6, 5] = new Pawn(true);
            Squares[6, 7] = new Pawn(true);
            Squares[6, 9] = new Pawn(true);
            Squares[7, 0] = new Pawn(true);
            Squares[7, 2] = new Pawn(true);
            Squares[7, 4] = new Pawn(true);
            Squares[7, 6] = new Pawn(true);
            Squares[7, 8] = new Pawn(true);
            Squares[8, 1] = new Pawn(true);
            Squares[8, 3] = new Pawn(true);
            Squares[8, 5] = new Pawn(true);
            Squares[8, 7] = new Pawn(true);
            Squares[8, 9] = new Pawn(true);
            Squares[9, 0] = new Pawn(true);
            Squares[9, 2] = new Pawn(true);
            Squares[9, 4] = new Pawn(true);
            Squares[9, 6] = new Pawn(true);
            Squares[9, 8] = new Pawn(true);

            // Piezas rojas
            Squares[0, 1] = new Pawn(false);
            Squares[0, 3] = new Pawn(false);
            Squares[0, 5] = new Pawn(false);
            Squares[0, 7] = new Pawn(false);
            Squares[0, 9] = new Pawn(false);
            Squares[1, 0] = new Pawn(false);
            Squares[1, 2] = new Pawn(false);
            Squares[1, 4] = new Pawn(false);
            Squares[1, 6] = new Pawn(false);
            Squares[1, 8] = new Pawn(false);
            Squares[2, 1] = new Pawn(false);
            Squares[2, 3] = new Pawn(false);
            Squares[2, 5] = new Pawn(false);
            Squares[2, 7] = new Pawn(false);
            Squares[2, 9] = new Pawn(false);
            Squares[3, 0] = new Pawn(false);
            Squares[3, 2] = new Pawn(false);
            Squares[3, 4] = new Pawn(false);
            Squares[3, 6] = new Pawn(false);
            Squares[3, 8] = new Pawn(false);
        }

        public void American()
        {
            SquareSize = 8;
            Letters = ListLetter();
            Squares = new Piece[SquareSize, SquareSize];

            // Piezas blancas
            Squares[5, 0] = new Pawn(true);
            Squares[5, 2] = new Pawn(true);
            Squares[5, 4] = new Pawn(true);
            Squares[5, 6] = new Pawn(true);
            Squares[6, 1] = new Pawn(true);
            Squares[6, 3] = new Pawn(true);
            Squares[6, 5] = new Pawn(true);
            Squares[6, 7] = new Pawn(true);
            Squares[7, 0] = new Pawn(true);
            Squares[7, 2] = new Pawn(true);
            Squares[7, 4] = new Pawn(true);
            Squares[7, 6] = new Pawn(true);

            // Piezas rojas
            Squares[0, 1] = new Pawn(false);
            Squares[0, 3] = new Pawn(false);
            Squares[0, 5] = new Pawn(false);
            Squares[0, 7] = new Pawn(false);
            Squares[1, 0] = new Pawn(false);
            Squares[1, 2] = new Pawn(false);
            Squares[1, 4] = new Pawn(false);
            Squares[1, 6] = new Pawn(false);
            Squares[2, 1] = new Pawn(false);
            Squares[2, 3] = new Pawn(false);
            Squares[2, 5] = new Pawn(false);
            Squares[2, 7] = new Pawn(false);
        }
        #endregion

    }
}
