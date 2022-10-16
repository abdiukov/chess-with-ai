using System.Collections.Generic;
using System.Drawing;
using ChessGame.Data;
using ChessGame.Model;

namespace ChessGame.Service;

public class ChessMovementService
{
    private Team _pieceTeam;
    public List<Point?> GetPossibleMoves(Piece piece, int x, int y)
    {
        List<Point?> movableSquares = new();
        _pieceTeam = piece.Team;

        movableSquares = piece switch
        {
            Pawn => _pieceTeam == Team.White ? GetMovesWhitePawn(x, y) : GetMovesBlackPawn(x, y),
            Knight => GetMovesKnight(x, y),
            Rook => GetMovesRook(x, y),
            Bishop => GetMovesBishop(x, y),
            King => GetMovesKing(x, y),
            Queen => GetMovesQueen(x, y),
            _ => movableSquares
        };

        //returns the highlighted squares
        return movableSquares;
    }



    private List<Point?> GetMovesBlackPawn(int x, int y)
    {
        List<Point?> output = new();

        if (IsEmpty(x, y + 1) == true)
        {
            output.Add(new Point(x, y + 1));
            if (y == 1)
            {
                if (IsEmpty(x, y + 2) == true)
                {
                    output.Add(new Point(x, y + 2));
                }
            }
        }
        if (IsEmpty(x + 1, y + 1) == false)
        {
            output.Add(new Point(x + 1, y + 1));
        }

        if (IsEmpty(x - 1, y + 1) == false)
        {
            output.Add(new Point(x - 1, y + 1));
        }

        return output;
    }

    private List<Point?> GetMovesWhitePawn(int x, int y)
    {
        List<Point?> output = new();

        if (IsEmpty(x, y - 1) == true)
        {
            output.Add(new Point(x, y - 1));
            if (y == 6)
            {
                if (IsEmpty(x, y - 2) == true)
                {
                    output.Add(new Point(x, y - 2));
                }
            }
        }

        if (IsEmpty(x + 1, y - 1) == false)
        {
            output.Add(new Point(x + 1, y - 1));
        }

        if (IsEmpty(x - 1, y - 1) == false)
        {
            output.Add(new Point(x - 1, y - 1));
        }

        return output;
    }





    private List<Point?> GetMovesRook(int x, int y)
    {
        List<Point?> output = new();


        //checking moves from the left
        for (int i = x - 1, exitLoop = 0; exitLoop == 0; i--)
        {
            switch (IsEmpty(i, y))
            {
                case true:
                    output.Add(new Point(i, y));
                    break;
                case false:
                    output.Add(new Point(i, y));
                    exitLoop = 1;
                    break;
                case null:
                    exitLoop = 1;
                    break;
            }
        }

        //checking moves from the right
        for (int i = x + 1, exitLoop = 0; exitLoop == 0; i++)
        {
            switch (IsEmpty(i, y))
            {
                case true:
                    output.Add(new Point(i, y));
                    break;
                case false:
                    output.Add(new Point(i, y));
                    exitLoop = 1;
                    break;
                case null:
                    exitLoop = 1;
                    break;
            }
        }

        //checking moves from above

        for (int i = y - 1, exitLoop = 0; exitLoop == 0; i--)
        {
            switch (IsEmpty(x, i))
            {
                case true:
                    output.Add(new Point(x, i));
                    break;
                case false:
                    output.Add(new Point(x, i));
                    exitLoop = 1;
                    break;
                case null:
                    exitLoop = 1;
                    break;
            }
        }


        //checking moves from below
        for (int i = y + 1, exitLoop = 0; exitLoop == 0; i++)
        {
            switch (IsEmpty(x, i))
            {
                case true:
                    output.Add(new Point(x, i));
                    break;
                case false:
                    output.Add(new Point(x, i));
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


    private List<Point?> GetMovesKing(int x, int y)
    {
        List<Point?> output = new();

        //move right up and down -  from the white side perspective
        //so for example from the black perspective, up would be down, down would be up etc

        //right = x+1
        //left = x-1
        //up y-1
        //down y+1

        //up and down
        if (IsEmpty(x, y - 1) != null) { output.Add(new Point(x, y - 1)); }

        if (IsEmpty(x, y + 1) != null) { output.Add(new Point(x, y + 1)); }

        //left and right
        if (IsEmpty(x + 1, y) != null) { output.Add(new Point(x + 1, y)); }

        if (IsEmpty(x - 1, y) != null) { output.Add(new Point(x - 1, y)); }

        //left up
        if (IsEmpty(x - 1, y - 1) != null) { output.Add(new Point(x - 1, y - 1)); }

        //left down
        if (IsEmpty(x - 1, y + 1) != null) { output.Add(new Point(x - 1, y + 1)); }

        //right up
        if (IsEmpty(x + 1, y - 1) != null) { output.Add(new Point(x + 1, y - 1)); }

        //right down
        if (IsEmpty(x + 1, y + 1) != null) { output.Add(new Point(x + 1, y + 1)); }

        if (Information.HasMyKingMovedBefore() || (y != 7 && y != 0)) return output;
        //checking from right side
        if (IsEmpty(x + 1, y) == true && IsEmpty(x + 2, y) == true
                                      && IsFriendlyRook(x + 3, y))
        {
            output.Add(new Point(x + 2, y));
        }

        //checking from left side
        if (IsEmpty(x - 1, y) == true && IsEmpty(x - 2, y) == true &&
            IsEmpty(x - 3, y) == true && IsFriendlyRook(x - 4, y))
        {
            output.Add(new Point(x - 2, y));
        }

        return output;
    }

    private List<Point?> GetMovesBishop(int x, int y)
    {
        List<Point?> output = new();

        //right down

        for (int xValue = x + 1, yValue = y + 1, exitLoop = 0; exitLoop == 0; xValue++, yValue++)
        {
            switch (IsEmpty(xValue, yValue))
            {
                case true:
                    output.Add(new Point(xValue, yValue));
                    break;
                case false:
                    output.Add(new Point(xValue, yValue));
                    exitLoop = 1;
                    break;
                case null:
                    exitLoop = 1;
                    break;
            }
        }

        //right up
        for (int xValue = x + 1, yValue = y - 1, exitLoop = 0; exitLoop == 0; xValue++, yValue--)
        {
            switch (IsEmpty(xValue, yValue))
            {
                case true:
                    output.Add(new Point(xValue, yValue));
                    break;
                case false:
                    output.Add(new Point(xValue, yValue));
                    exitLoop = 1;
                    break;
                case null:
                    exitLoop = 1;
                    break;
            }
        }


        //left up
        for (int xValue = x - 1, yValue = y - 1, exitLoop = 0; exitLoop == 0; xValue--, yValue--)
        {

            switch (IsEmpty(xValue, yValue))
            {
                case true:
                    output.Add(new Point(xValue, yValue));
                    break;
                case false:
                    output.Add(new Point(xValue, yValue));
                    exitLoop = 1;
                    break;
                case null:
                    exitLoop = 1;
                    break;
            }
        }

        //left down

        for (int xValue = x - 1, yValue = y + 1, exitLoop = 0; exitLoop == 0; xValue--, yValue++)
        {
            switch (IsEmpty(xValue, yValue))
            {
                case true:
                    output.Add(new Point(xValue, yValue));
                    break;
                case false:
                    output.Add(new Point(xValue, yValue));
                    exitLoop = 1;
                    break;
                case null:
                    exitLoop = 1;
                    break;
            }
        }

        return output;
    }

    private List<Point?> GetMovesKnight(int x, int y)
    {
        List<Point?> output = new();

        //up left

        if (IsEmpty(x - 1, y - 2) != null) { output.Add(new Point(x - 1, y - 2)); }
        //up right

        if (IsEmpty(x + 1, y - 2) != null) { output.Add(new Point(x + 1, y - 2)); }

        //down left

        if (IsEmpty(x - 1, y + 2) != null) { output.Add(new Point(x - 1, y + 2)); }

        //down right

        if (IsEmpty(x + 1, y + 2) != null) { output.Add(new Point(x + 1, y + 2)); }

        //left up

        if (IsEmpty(x - 2, y - 1) != null) { output.Add(new Point(x - 2, y - 1)); }

        //left down

        if (IsEmpty(x - 2, y + 1) != null) { output.Add(new Point(x - 2, y + 1)); }

        //right up
        if (IsEmpty(x + 2, y - 1) != null) { output.Add(new Point(x + 2, y - 1)); }

        //right down
        if (IsEmpty(x + 2, y + 1) != null) { output.Add(new Point(x + 2, y + 1)); }

        return output;
    }


    private List<Point?> GetMovesQueen(int x, int y)
    {
        List<Point?> output = new();

        output.AddRange(GetMovesBishop(x, y));
        output.AddRange(GetMovesRook(x, y));

        return output;
    }


    /// <summary>
    ///Checks whether the coordinate on the board is empty
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <returns>Returns true if piece is empty. Returns false if piece is not empty and is enemy team. Returns null if it is not empty and it is your team.</returns>
    private bool? IsEmpty(int x, int y)
    {
        if (x is < 0 or > 7 || y is < 0 or > 7) 
            return null;

        if (Coordinates.Board[x, y].Piece is null)
        {
            return true;
        }

        if (Coordinates.Board[x, y].Piece.Team != _pieceTeam)
        {
            return false;
        }
        return null;
    }

    private bool IsFriendlyRook(int x, int y)
    {
        if (x is < 0 or > 7 || y is < 0 or > 7) 
            return false;

        if (Coordinates.Board[x, y].Piece is null) 
            return false;

        return Coordinates.Board[x, y].Piece is Rook
               && Coordinates.Board[x, y].Piece.Team == _pieceTeam;
    }

}