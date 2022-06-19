using CheckersGame.Boards;
using CheckersGame.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckersGame
{
    public class Game
    {
        #region Properties
        public Board GameBoard { get; }
        public bool IsPlayer1Turn { get; private set; }
        #endregion

        #region Constructor
        public Game()
        {
            GameBoard = new PolishBoard();
            IsPlayer1Turn = true;
        }
        public Game(int size)
        {
            switch (size)
            {
                case 1:
                    GameBoard = new AmericanBoard();
                    break;
                case 2:
                    GameBoard = new InternationalBoard();
                    break;
                case 3:
                    GameBoard = new PolishBoard();
                    break;
            }
            IsPlayer1Turn = true;
        }
        #endregion

        #region Methods
        public void Loop()
        {
            string inputStart;
            string inputTo;

            GameBoard.Show();
            ShowTurn();

            while (true)
            {
                if (IsGameEnd())
                {
                    Console.WriteLine("\nThere are no more moves. End");
                    break;
                }

                Console.Write("\nPIECE TO MOVE: ");
                inputStart = Console.ReadLine();
                int[] start = GetCoordinates(inputStart);
                if (start == null)
                {
                    continue;
                }

                Console.Write("DESTINATION: ");
                inputTo = Console.ReadLine();
                List<int[]> to = MultipleCoordinate(inputTo);
                if (to == null)
                {
                    continue;
                }

                bool isValidMove = true;
                foreach (int[] point in to)
                {
                    isValidMove = MovePiece(start, point);
                    if (!isValidMove)
                    {
                        break;
                    }
                    start = point;
                }

                if (!isValidMove)
                {
                    continue;
                }

                RemoveCapturedPieces(start);
                IsPlayer1Turn = !IsPlayer1Turn;
                GameBoard.Crowning();
                GameBoard.Show();
                ShowTurn();

            }
        }



        public bool MovePiece(int[] start, int[] to)
        {
            IPiece movedPiece = GameBoard.Squares[start[0], start[1]];
            IPiece endPiece = GameBoard.Squares[to[0], to[1]];
            bool toIsValid = endPiece != null;
            bool isPlayerTurn = (IsPlayer1Turn == movedPiece.IsWhite);

            if (movedPiece == null)
            {
                Console.WriteLine("There is no piece to move at the start place");
                return false;
            }

            if (!isPlayerTurn)
            {
                Console.WriteLine("That's not your piece to move");
                return false;
            }

            if (toIsValid)
            {
                Console.WriteLine("There is already a piece in the destination place");
                return false;
            }

            if (movedPiece.IsValidMove(GameBoard, start, to))
            {
                IPiece piece = GameBoard.Squares[start[0], start[1]];
                GameBoard.Squares[start[0], start[1]] = null;
                GameBoard.Squares[to[0], to[1]] = piece;
                return true;
            }
            else
            {
                Console.WriteLine("Invalid move");
                return false;
            }
        }

        public int[] GetCoordinates(string input)
        {
            int minInputCharacters = 2;
            int coordinateX;
            char coordinateY;
            input = input.ToUpper();

            if (input.Length >= minInputCharacters)
            {
                coordinateY = input[0];
                coordinateX = Convert.ToInt32(input[1..]) - 1;
            }
            else
            {
                Console.WriteLine("Invalid input: '{0}'", input);
                return null;
            }

            int int_coordinateY = coordinateY - 'A';
            int[] coordinate = new int[] { int_coordinateY, coordinateX };

            if (IsValidCoordinate(coordinate))
            {
                return coordinate;
            }
            else
            {
                return null;
            }
        }

        public bool IsValidCoordinate(int[] coordinate)
        {
            int coordinateX = coordinate[0];
            int coordinateY = coordinate[1];

            bool isInvalidCoordinateX = (coordinateX < 0 && coordinateX >= GameBoard.SquareSize);
            if (isInvalidCoordinateX)
            {
                Console.WriteLine("Row does not exist: '{0}' ", coordinateX);
                return false;
            }

            bool isInvalidCoordinateY = (coordinateY < 0 && coordinateY >= GameBoard.SquareSize);
            if (isInvalidCoordinateY)
            {
                Console.WriteLine("Column does not exist: '{0}' ", coordinateY);
                return false;
            }

            return true;
        }

        private bool IsGameEnd()
        {
            bool canMove=false;
            int countRedPieces = 0;
            int countWhitePieces = 0;
            IPiece[,] pieces = GameBoard.Squares;
            for (int column = 0; column < pieces.GetLength(0); column += 1)
            {
                for (int row = 0; row < pieces.GetLength(1); row += 1)
                {
                    int[] start = new int[2] { column, row };
                 

                    if (pieces[column, row] != null)
                    {
                        if (!canMove)
                        {
                            canMove = GameBoard.CanPieceMove(start);
                        }

                        if (pieces[column, row].IsWhite)
                        {
                            countWhitePieces++;
                        }
                        else
                        {
                            countRedPieces++;
                        }

                        if (canMove)
                        {
                            if (countRedPieces != 0 && countWhitePieces != 0)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private List<int[]> MultipleCoordinate(string input)
        {
            List<int[]> result = new List<int[]>();
            string[] coordinates = input.Split(",");

            foreach (string coordinate in coordinates)
            {
                int[] coord = GetCoordinates(coordinate);
                result.Add(coord);
            }

            return result;
        }

        private void RemoveCapturedPieces(int[] coordinates)
        {
            IPiece piece = GameBoard.Squares[coordinates[0], coordinates[1]];

            foreach (int[] coordinatesCapturedPieces in piece.CapturedPieces)
            {
                GameBoard.Squares[coordinatesCapturedPieces[0], coordinatesCapturedPieces[1]] = null;
            }
            piece.CapturedPieces = new List<int[]>();
        }

        private void ShowTurn()
        {
            string messageTurn;

            if (IsPlayer1Turn)
            {
                messageTurn = "\n\n------- Player 1 -------";
            }
            else
            {
                messageTurn = "\n\n------- Player 2 -------";
            }
            Console.WriteLine(messageTurn);
        }
        #endregion

    }
}

