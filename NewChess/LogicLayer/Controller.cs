using ChessBoardAssets;
using System.Collections.Generic;
using System.Drawing;

namespace LogicLayer
{

    public class Controller
    {

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


            return movableSquares;
            //returns the highlighted squares

            //the program then looks at these highlighted squares and moves there
        }



        private List<Point?> GetMovesBlackPawn(int X, int Y)
        {
            List<Point?> output = new List<Point?>();
            if (Coordinates.IsEmpty(X, Y + 1) == true)
            {
                output.Add(new Point(X, Y + 1));
                if (Y == 1)
                {
                    if (Coordinates.IsEmpty(X, Y + 2) == true)
                    {
                        output.Add(new Point(X, Y + 2));
                    }
                }
            }
            if (Coordinates.IsEmpty(X + 1, Y + 1) == false)
            {
                output.Add(new Point(X + 1, Y + 1));
            }
            if (Coordinates.IsEmpty(X - 1, Y + 1) == false)
            {
                output.Add(new Point(X - 1, Y + 1));
            }

            return output;
        }

        private List<Point?> GetMovesWhitePawn(int X, int Y)
        {
            List<Point?> output = new List<Point?>();
            if (Coordinates.IsEmpty(X, Y - 1) == true)
            {
                output.Add(new Point(X, Y - 1));
                if (Y == 6)
                {
                    if (Coordinates.IsEmpty(X, Y - 2) == true)
                    {
                        output.Add(new Point(X, Y - 2));
                    }
                }
            }
            if (Coordinates.IsEmpty(X + 1, Y - 1) == false)
            {
                output.Add(new Point(X + 1, Y - 1));
            }
            if (Coordinates.IsEmpty(X - 1, Y - 1) == false)
            {
                output.Add(new Point(X - 1, Y - 1));
            }
            return output;
        }





        private List<Point?> GetMovesRook(int X, int Y)
        {
            List<Point?> output = new List<Point?>();
            bool ExitLoop = false;

            //checking moves from the left
            for (int i = X - 1; ExitLoop == false; i--)
            {
                if (Coordinates.IsEmpty(i, Y) == true)
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
                if (Coordinates.IsEmpty(i, Y) == true)
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
                if (Coordinates.IsEmpty(X, i) == true)
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
                if (Coordinates.IsEmpty(X, i) == true)
                {
                    output.Add(new Point(X, i));
                }
                else
                {
                    ExitLoop = true;
                }
            }

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
            if (Coordinates.IsEmpty(X, Y - 1) == true) { output.Add(new Point(X, Y - 1)); }

            if (Coordinates.IsEmpty(X, Y + 1) == true) { output.Add(new Point(X, Y + 1)); }

            //left and right
            if (Coordinates.IsEmpty(X + 1, Y) == true) { output.Add(new Point(X + 1, Y)); }
            if (Coordinates.IsEmpty(X - 1, Y) == true) { output.Add(new Point(X - 1, Y)); }

            //left up
            if (Coordinates.IsEmpty(X - 1, Y - 1) == true) { output.Add(new Point(X - 1, Y - 1)); }

            //left down
            if (Coordinates.IsEmpty(X - 1, Y + 1) == true) { output.Add(new Point(X - 1, Y + 1)); }

            //right up
            if (Coordinates.IsEmpty(X + 1, Y - 1) == true) { output.Add(new Point(X + 1, Y - 1)); }

            //right down
            if (Coordinates.IsEmpty(X + 1, Y + 1) == true) { output.Add(new Point(X + 1, Y + 1)); }

            return output;
        }

        private List<Point?> GetMovesBishop(int X, int Y)
        {
            List<Point?> output = new List<Point?>();

            bool ExitLoop = false;

            //right down

            for (int x = X + 1, y = Y + 1; ExitLoop == false; x++, y++)
            {
                if (Coordinates.IsEmpty(x, y) == true) { output.Add(new Point(x, y)); }
                else
                {
                    ExitLoop = true;
                }
            }

            //right up
            ExitLoop = false;

            for (int x = X + 1, y = Y - 1; ExitLoop == false; x++, y--)
            {
                if (Coordinates.IsEmpty(x, y) == true) { output.Add(new Point(x, y)); }
                else
                {
                    ExitLoop = true;
                }
            }


            //left up
            ExitLoop = false;

            for (int x = X - 1, y = Y - 1; ExitLoop == false; x--, y--)
            {
                if (Coordinates.IsEmpty(x, y) == true) { output.Add(new Point(x, y)); }
                else
                {
                    ExitLoop = true;
                }
            }

            //left down
            ExitLoop = false;

            for (int x = X - 1, y = Y + 1; ExitLoop == false; x--, y++)
            {
                if (Coordinates.IsEmpty(x, y) == true) { output.Add(new Point(x, y)); }
                else
                {
                    ExitLoop = true;
                }
            }

            return output;
        }

        private List<Point?> GetMovesKnight(int X, int Y)
        {
            List<Point?> output = new List<Point?>();

            //http://www.chesscorner.com/tutorial/basic/knight/knight.htm

            //up left

            if (Coordinates.IsEmpty(X - 1, Y - 2) == true) { output.Add(new Point(X - 1, Y - 2)); }

            //y decreases by 2
            //x decreases by 1

            //up right

            if (Coordinates.IsEmpty(X + 1, Y - 2) == true) { output.Add(new Point(X + 1, Y - 2)); }

            //y decreases by 2
            //x increases by 1


            //down left

            if (Coordinates.IsEmpty(X - 1, Y + 2) == true) { output.Add(new Point(X - 1, Y + 2)); }


            //y increases by 2
            //x decreases by 1

            //down right

            if (Coordinates.IsEmpty(X + 1, Y + 2) == true) { output.Add(new Point(X + 1, Y + 2)); }


            //y increases by 2
            //x incrases by 1


            //left up

            if (Coordinates.IsEmpty(X - 2, Y - 1) == true) { output.Add(new Point(X - 2, Y - 1)); }

            //x decreases by 2
            //y decreases by 1

            //left down

            if (Coordinates.IsEmpty(X - 2, Y + 1) == true) { output.Add(new Point(X - 2, Y + 1)); }


            //x decreases by 2
            //y increases by 1

            //right up
            if (Coordinates.IsEmpty(X + 2, Y - 1) == true) { output.Add(new Point(X + 2, Y - 1)); }
            //x increases by 2
            //y decreases by 1

            //right down
            if (Coordinates.IsEmpty(X + 2, Y + 1) == true) { output.Add(new Point(X + 2, Y + 1)); }
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


    }
}
