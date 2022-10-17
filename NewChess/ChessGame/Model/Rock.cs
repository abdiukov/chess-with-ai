using System.Collections.Generic;
using System.Drawing;

namespace ChessGame.Model;

public class Rook : Piece
{
    public Rook(Team team)
        : base(team, "Rook") { }

    public override IList<Point?> GetMoves(int x, int y)
    {
        var moves = new List<Point?>();

        //checking moves from the left
        for (int i = x - 1, exitLoop = 0; exitLoop == 0; i--)
        {
            switch (IsEmpty(i, y, this))
            {
                case true:
                    moves.Add(new Point(i, y));
                    break;
                case false:
                    moves.Add(new Point(i, y));
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
            switch (IsEmpty(i, y, this))
            {
                case true:
                    moves.Add(new Point(i, y));
                    break;
                case false:
                    moves.Add(new Point(i, y));
                    exitLoop = 1;
                    continue;
                case null:
                    exitLoop = 1;
                    break;
            }
        }

        //checking moves from above
        for (int i = y - 1, exitLoop = 0; exitLoop == 0; i--)
        {
            switch (IsEmpty(x, i, this))
            {
                case true:
                    moves.Add(new Point(x, i));
                    break;
                case false:
                    moves.Add(new Point(x, i));
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
            switch (IsEmpty(x, i, this))
            {
                case true:
                    moves.Add(new Point(x, i));
                    break;
                case false:
                    moves.Add(new Point(x, i));
                    exitLoop = 1;
                    break;
                case null:
                    exitLoop = 1;
                    break;
            }
        }
        //return all the moves
        return moves;
    }
}