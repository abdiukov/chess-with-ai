using System.Collections.Generic;
using System.Drawing;

namespace ChessGame.Model;

public class Pawn : Piece
{
    public Pawn(Team team)
        : base(team, "Pawn") { }

    public override IList<Point?> GetMoves(int x, int y)
    {
        return Team == Team.White ? GetMovesWhitePawn(x, y) : GetMovesBlackPawn(x, y);
    }

    private List<Point?> GetMovesBlackPawn(int x, int y)
    {
        var output = new List<Point?>();

        if (IsEmpty(x, y + 1, this) == true)
        {
            output.Add(new Point(x, y + 1));
            if (y == 1)
                if (IsEmpty(x, y + 2, this) == true)
                    output.Add(new Point(x, y + 2));

        }
        if (IsEmpty(x + 1, y + 1, this) == false)
            output.Add(new Point(x + 1, y + 1));

        if (IsEmpty(x - 1, y + 1, this) == false)
            output.Add(new Point(x - 1, y + 1));

        return output;
    }
    private List<Point?> GetMovesWhitePawn(int x, int y)
    {
        var output = new List<Point?>();

        if (IsEmpty(x, y - 1, this) == true)
        {
            output.Add(new Point(x, y - 1));
            if (y == 6)
                if (IsEmpty(x, y - 2, this) == true)
                    output.Add(new Point(x, y - 2));
        }

        if (IsEmpty(x + 1, y - 1, this) == false)
            output.Add(new Point(x + 1, y - 1));

        if (IsEmpty(x - 1, y - 1, this) == false)
            output.Add(new Point(x - 1, y - 1));

        return output;
    }
}