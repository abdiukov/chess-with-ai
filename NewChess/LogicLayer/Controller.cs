using ChessBoardAssets;
using GameInfo;
using System.Collections.Generic;
using System.Drawing;

namespace LogicLayer
{

    public class Controller
    {
        public List<Point?> GetPossibleMoves(Piece piece, int X, int Y)
        {
            List<Point?> movableSquares = new();

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

            //returns the highlighted squares
            return movableSquares;
        }



        private List<Point?> GetMovesBlackPawn(int X, int Y)
        {
            List<Point?> output = new();

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
            if (IsEmpty(X + 1, Y + 1) == false)
            {
                output.Add(new Point(X + 1, Y + 1));
            }

            if (IsEmpty(X - 1, Y + 1) == false)
            {
                output.Add(new Point(X - 1, Y + 1));
            }

            return output;
        }

        private List<Point?> GetMovesWhitePawn(int X, int Y)
        {
            List<Point?> output = new();

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

            if (IsEmpty(X + 1, Y - 1) == false)
            {
                output.Add(new Point(X + 1, Y - 1));
            }

            if (IsEmpty(X - 1, Y - 1) == false)
            {
                output.Add(new Point(X - 1, Y - 1));
            }

            return output;
        }





        private List<Point?> GetMovesRook(int X, int Y)
        {
            List<Point?> output = new();


            //checking moves from the left
            for (int i = X - 1, exitLoop = 0; exitLoop == 0; i--)
            {
                switch (IsEmpty(i, Y))
                {
                    case true:
                        output.Add(new Point(i, Y));
                        break;
                    case false:
                        output.Add(new Point(i, Y));
                        exitLoop = 1;
                        break;
                    case null:
                        exitLoop = 1;
                        break;
                }
            }

            //checking moves from the right
            for (int i = X + 1, exitLoop = 0; exitLoop == 0; i++)
            {
                switch (IsEmpty(i, Y))
                {
                    case true:
                        output.Add(new Point(i, Y));
                        break;
                    case false:
                        output.Add(new Point(i, Y));
                        exitLoop = 1;
                        break;
                    case null:
                        exitLoop = 1;
                        break;
                }
            }

            //checking moves from above

            for (int i = Y - 1, exitLoop = 0; exitLoop == 0; i--)
            {
                switch (IsEmpty(X, i))
                {
                    case true:
                        output.Add(new Point(X, i));
                        break;
                    case false:
                        output.Add(new Point(X, i));
                        exitLoop = 1;
                        break;
                    case null:
                        exitLoop = 1;
                        break;
                }
            }


            //checking moves from below
            for (int i = Y + 1, exitLoop = 0; exitLoop == 0; i++)
            {
                switch (IsEmpty(X, i))
                {
                    case true:
                        output.Add(new Point(X, i));
                        break;
                    case false:
                        output.Add(new Point(X, i));
                        exitLoop = 1;
                        break;
                    case null:
                        exitLoop = 1;
                        break;
                }
            }
            //return all the moves
            return output;
        }


        private List<Point?> GetMovesKing(int X, int Y)
        {
            List<Point?> output = new();

            //move right up and down -  from the white side perspective
            //so for example from the black perspective, up would be down, down would be up etc

            //right = x+1
            //left = x-1
            //up y-1
            //down y+1

            //up and down
            if (IsEmpty(X, Y - 1) != null) { output.Add(new Point(X, Y - 1)); }

            if (IsEmpty(X, Y + 1) != null) { output.Add(new Point(X, Y + 1)); }

            //left and right
            if (IsEmpty(X + 1, Y) != null) { output.Add(new Point(X + 1, Y)); }

            if (IsEmpty(X - 1, Y) != null) { output.Add(new Point(X - 1, Y)); }

            //left up
            if (IsEmpty(X - 1, Y - 1) != null) { output.Add(new Point(X - 1, Y - 1)); }

            //left down
            if (IsEmpty(X - 1, Y + 1) != null) { output.Add(new Point(X - 1, Y + 1)); }

            //right up
            if (IsEmpty(X + 1, Y - 1) != null) { output.Add(new Point(X + 1, Y - 1)); }

            //right down
            if (IsEmpty(X + 1, Y + 1) != null) { output.Add(new Point(X + 1, Y + 1)); }

            if (Information.HasMyKingMovedBefore() == false && (Y == 7 || Y == 0))
            {
                //checking from right side
                if (IsEmpty(X + 1, Y) == true && IsEmpty(X + 2, Y) == true
                    && IsFriendlyRook(X + 3, Y) == true)
                {
                    output.Add(new Point(X + 2, Y));
                }

                //checking from left side

                //checking from right side
                if (IsEmpty(X - 1, Y) == true && IsEmpty(X - 2, Y) == true &&
                   IsEmpty(X - 3, Y) == true && IsFriendlyRook(X - 4, Y) == true)
                {
                    output.Add(new Point(X - 2, Y));
                }
            }

            return output;
        }

        private List<Point?> GetMovesBishop(int X, int Y)
        {
            List<Point?> output = new();

            //right down

            for (int x = X + 1, y = Y + 1, exitLoop = 0; exitLoop == 0; x++, y++)
            {
                switch (IsEmpty(x, y))
                {
                    case true:
                        output.Add(new Point(x, y));
                        break;
                    case false:
                        output.Add(new Point(x, y));
                        exitLoop = 1;
                        break;
                    case null:
                        exitLoop = 1;
                        break;
                }
            }

            //right up
            for (int x = X + 1, y = Y - 1, exitLoop = 0; exitLoop == 0; x++, y--)
            {
                switch (IsEmpty(x, y))
                {
                    case true:
                        output.Add(new Point(x, y));
                        break;
                    case false:
                        output.Add(new Point(x, y));
                        exitLoop = 1;
                        break;
                    case null:
                        exitLoop = 1;
                        break;
                }
            }


            //left up
            for (int x = X - 1, y = Y - 1, exitLoop = 0; exitLoop == 0; x--, y--)
            {

                switch (IsEmpty(x, y))
                {
                    case true:
                        output.Add(new Point(x, y));
                        break;
                    case false:
                        output.Add(new Point(x, y));
                        exitLoop = 1;
                        break;
                    case null:
                        exitLoop = 1;
                        break;
                }
            }

            //left down

            for (int x = X - 1, y = Y + 1, exitLoop = 0; exitLoop == 0; x--, y++)
            {
                switch (IsEmpty(x, y))
                {
                    case true:
                        output.Add(new Point(x, y));
                        break;
                    case false:
                        output.Add(new Point(x, y));
                        exitLoop = 1;
                        break;
                    case null:
                        exitLoop = 1;
                        break;
                }
            }

            return output;
        }

        private List<Point?> GetMovesKnight(int X, int Y)
        {
            List<Point?> output = new();

            //up left

            if (IsEmpty(X - 1, Y - 2) != null) { output.Add(new Point(X - 1, Y - 2)); }
            //up right

            if (IsEmpty(X + 1, Y - 2) != null) { output.Add(new Point(X + 1, Y - 2)); }

            //down left

            if (IsEmpty(X - 1, Y + 2) != null) { output.Add(new Point(X - 1, Y + 2)); }

            //down right

            if (IsEmpty(X + 1, Y + 2) != null) { output.Add(new Point(X + 1, Y + 2)); }

            //left up

            if (IsEmpty(X - 2, Y - 1) != null) { output.Add(new Point(X - 2, Y - 1)); }

            //left down

            if (IsEmpty(X - 2, Y + 1) != null) { output.Add(new Point(X - 2, Y + 1)); }

            //right up
            if (IsEmpty(X + 2, Y - 1) != null) { output.Add(new Point(X + 2, Y - 1)); }

            //right down
            if (IsEmpty(X + 2, Y + 1) != null) { output.Add(new Point(X + 2, Y + 1)); }

            return output;
        }


        private List<Point?> GetMovesQueen(int X, int Y)
        {
            List<Point?> output = new();

            output.AddRange(GetMovesBishop(X, Y));
            output.AddRange(GetMovesRook(X, Y));

            return output;
        }


        /// <summary>
        ///Checks whether the coordinate on the board is empty
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Returns true if piece is empty. Returns false if piece is not empty and is enemy team. Returns null if it is not empty and it is your team.</returns>
        private static bool? IsEmpty(int x, int y)
        {
            if (x >= 0 && x <= 7 && y >= 0 && y <= 7)
            {
                if (Coordinates.board[x, y].piece is null)
                {
                    return true;
                }
                else if (Coordinates.board[x, y].piece.Team != Information.currentPlayer)
                {
                    return false;
                }
            }
            return null;
        }

        private static bool IsFriendlyRook(int x, int y)
        {
            if (x >= 0 && x <= 7 && y >= 0 && y <= 7)
            {
                if (Coordinates.board[x, y].piece is not null)
                {
                    if (Coordinates.board[x, y].piece is Rook
                        && Coordinates.board[x, y].piece.Team == Information.currentPlayer)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}