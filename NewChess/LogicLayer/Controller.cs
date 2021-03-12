using ChessBoardAssets;
using GameInfo;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace LogicLayer
{

    public class Controller
    {
        private static bool ExitLoop = false;
        public List<Point?> GetPossibleMoves(Piece piece, int X, int Y)
        {
            List<Point?> movableSquares = new List<Point?>();

            switch (piece)
            {
                case Pawn:
                    if (piece.Team == Team.White)
                    {
                        movableSquares = GetMovesWhitePawn(X, Y);
                    }
                    else
                    {
                        movableSquares = GetMovesBlackPawn(X, Y);
                    }
                    break;
                case Knight:
                    movableSquares = GetMovesKnight(X, Y);
                    break;
                case Rook:
                    movableSquares = GetMovesRook(X, Y);
                    break;
                case Bishop:
                    movableSquares = GetMovesBishop(X, Y);
                    break;
                case King:
                    movableSquares = GetMovesKing(X, Y);
                    break;
                case Queen:
                    movableSquares = GetMovesQueen(X, Y);
                    break;
            }

            //Array array = new dynamic[] {1, 2, 3};

            return movableSquares;
            //returns the highlighted squares

            //the program then looks at these highlighted squares and moves there
        }



        private List<Point?> GetMovesBlackPawn(int X, int Y)
        {
            List<Point?> output = new List<Point?>();
            if (IsEmpty(X, Y + 1) == true)
            {
                output.Add(new Point(X, Y + 1));
                if (Y == 1)
                {
                    if (IsEmpty(X, Y + 2) == true)
                    {
                        output.Add(new Point(X, Y + 2));
                    }
                }
            }
            try
            {
                if (Coordinates.board[X + 1, Y + 1].piece is not null)
                {
                    if (Coordinates.board[X + 1, Y + 1].piece.Team != Information.currentPlayer)
                    {
                        output.Add(new Point(X + 1, Y + 1));
                    }
                }
                if (Coordinates.board[X - 1, Y + 1].piece is not null)
                {
                    if (Coordinates.board[X - 1, Y + 1].piece.Team != Information.currentPlayer)
                    {
                        output.Add(new Point(X - 1, Y + 1));
                    }
                }
            }
            catch (IndexOutOfRangeException) { }

            ExitLoop = false;

            return output;
        }

        private List<Point?> GetMovesWhitePawn(int X, int Y)
        {
            List<Point?> output = new List<Point?>();

            if (IsEmpty(X, Y - 1) == true)
            {
                output.Add(new Point(X, Y - 1));

                if (Y == 6)
                {
                    if (IsEmpty(X, Y - 2) == true)
                    {
                        output.Add(new Point(X, Y - 2));
                    }
                }
            }
            try
            {

                if (Coordinates.board[X + 1, Y - 1].piece is not null)
                {
                    if (Coordinates.board[X + 1, Y - 1].piece.Team != Information.currentPlayer)
                    {
                        output.Add(new Point(X + 1, Y - 1));
                    }
                }

                if (Coordinates.board[X - 1, Y - 1].piece is not null)
                {
                    if (Coordinates.board[X - 1, Y - 1].piece.Team != Information.currentPlayer)
                    {
                        output.Add(new Point(X - 1, Y - 1));
                    }
                }
            }
            catch (IndexOutOfRangeException) { }
            ExitLoop = false;

            return output;
        }





        private List<Point?> GetMovesRook(int X, int Y)
        {
            List<Point?> output = new List<Point?>();

            //checking moves from the left
            for (int i = X - 1; ExitLoop == false; i--)
            {
                if (IsEmpty(i, Y) == true)
                {
                    output.Add(new Point(i, Y));
                }
                else
                {
                    ExitLoop = true;
                }
            }

            //checking moves from the right

            ExitLoop = false;

            for (int i = X + 1; ExitLoop == false; i++)
            {
                if (IsEmpty(i, Y) == true)
                {
                    output.Add(new Point(i, Y));
                }
                else
                {
                    ExitLoop = true;
                }
            }

            //checking moves from above
            ExitLoop = false;

            for (int i = Y - 1; ExitLoop == false; i--)
            {
                if (IsEmpty(X, i) == true)
                {
                    output.Add(new Point(X, i));
                }
                else
                {
                    ExitLoop = true;
                }
            }

            //checking moves from below
            ExitLoop = false;

            for (int i = Y + 1; ExitLoop == false; i++)
            {
                if (IsEmpty(X, i) == true)
                {
                    output.Add(new Point(X, i));
                }
                else
                {
                    ExitLoop = true;
                }
            }
            ExitLoop = false;

            //return all the moves
            return output;

        }
        private List<Point?> GetMovesKing(int X, int Y)
        {
            List<Point?> output = new List<Point?>();

            //move right up and down -  from the white side perspective
            //so for example from the black perspective, up would be down, down would be up etc

            //right = x+1
            //left = x-1
            //up y-1
            //down y+1

            //up and down
            if (IsEmpty(X, Y - 1) == true) { output.Add(new Point(X, Y - 1)); }

            if (IsEmpty(X, Y + 1) == true) { output.Add(new Point(X, Y + 1)); }

            //left and right
            if (IsEmpty(X + 1, Y) == true) { output.Add(new Point(X + 1, Y)); }

            if (IsEmpty(X - 1, Y) == true) { output.Add(new Point(X - 1, Y)); }


            //left up
            if (IsEmpty(X - 1, Y - 1) == true) { output.Add(new Point(X - 1, Y - 1)); }

            //left down
            if (IsEmpty(X - 1, Y + 1) == true) { output.Add(new Point(X - 1, Y + 1)); }

            //right up
            if (IsEmpty(X + 1, Y - 1) == true) { output.Add(new Point(X + 1, Y - 1)); }

            //right down
            if (IsEmpty(X + 1, Y + 1) == true) { output.Add(new Point(X + 1, Y + 1)); }
            ExitLoop = false;

            return output;
        }

        private List<Point?> GetMovesBishop(int X, int Y)
        {
            List<Point?> output = new List<Point?>();

            //right down

            for (int x = X + 1, y = Y + 1; ExitLoop == false; x++, y++)
            {
                if (IsEmpty(x, y) == true) { output.Add(new Point(x, y)); }
                else
                {
                    ExitLoop = true;
                }
            }

            //right up
            ExitLoop = false;

            for (int x = X + 1, y = Y - 1; ExitLoop == false; x++, y--)
            {
                if (IsEmpty(x, y) == true) { output.Add(new Point(x, y)); }
                else
                {
                    ExitLoop = true;
                }
            }


            //left up
            ExitLoop = false;

            for (int x = X - 1, y = Y - 1; ExitLoop == false; x--, y--)
            {
                if (IsEmpty(x, y) == true) { output.Add(new Point(x, y)); }
                else
                {
                    ExitLoop = true;
                }
            }

            //left down
            ExitLoop = false;

            for (int x = X - 1, y = Y + 1; ExitLoop == false; x--, y++)
            {
                if (IsEmpty(x, y) == true) { output.Add(new Point(x, y)); }
                else
                {
                    ExitLoop = true;
                }
            }
            ExitLoop = false;


            return output;
        }

        private List<Point?> GetMovesKnight(int X, int Y)
        {
            List<Point?> output = new List<Point?>();

            //http://www.chesscorner.com/tutorial/basic/knight/knight.htm

            //up left

            if (IsEmpty(X - 1, Y - 2) == true) { output.Add(new Point(X - 1, Y - 2)); }

            //y decreases by 2
            //x decreases by 1

            //up right

            if (IsEmpty(X + 1, Y - 2) == true) { output.Add(new Point(X + 1, Y - 2)); }

            //y decreases by 2
            //x increases by 1


            //down left

            if (IsEmpty(X - 1, Y + 2) == true) { output.Add(new Point(X - 1, Y + 2)); }


            //y increases by 2
            //x decreases by 1

            //down right

            if (IsEmpty(X + 1, Y + 2) == true) { output.Add(new Point(X + 1, Y + 2)); }


            //y increases by 2
            //x incrases by 1


            //left up

            if (IsEmpty(X - 2, Y - 1) == true) { output.Add(new Point(X - 2, Y - 1)); }

            //x decreases by 2
            //y decreases by 1

            //left down

            if (IsEmpty(X - 2, Y + 1) == true) { output.Add(new Point(X - 2, Y + 1)); }


            //x decreases by 2
            //y increases by 1

            //right up
            if (IsEmpty(X + 2, Y - 1) == true) { output.Add(new Point(X + 2, Y - 1)); }

            //x increases by 2
            //y decreases by 1

            //right down
            if (IsEmpty(X + 2, Y + 1) == true) { output.Add(new Point(X + 2, Y + 1)); }
            ExitLoop = false;

            //x increases by 2
            //y increases by 1


            return output;
        }


        private List<Point?> GetMovesQueen(int X, int Y)
        {
            List<Point?> output = new List<Point?>();

            output.AddRange(GetMovesBishop(X, Y));
            output.AddRange(GetMovesRook(X, Y));

            return output;
        }


        public static bool? IsEmpty(int x, int y)
        {
            try
            {
                if (Coordinates.board[x, y].piece is null)
                {
                    return true;
                }
                else if (Coordinates.board[x, y].piece.Team != Information.currentPlayer)
                {
                    ExitLoop = true;
                    return true;
                }
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            };
        }
    }

}
