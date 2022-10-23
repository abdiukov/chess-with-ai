using System.Collections.Generic;
using System.Drawing;

namespace ChessGame.Model;

public class King : Piece
{
    public bool HasMoved { get; set; } = false;
    public King(Team team)
        : base(team, "King") { }

    public override IList<Point?> GetMoves(int x, int y)
    {
        var output = new List<Point?>();

        //up and down
        if (IsEmpty(x, y - 1, this) != null)
            output.Add(new Point(x, y - 1));

        if (IsEmpty(x, y + 1, this) != null)
            output.Add(new Point(x, y + 1));

        //left and right
        if (IsEmpty(x + 1, y, this) != null)
            output.Add(new Point(x + 1, y));

        if (IsEmpty(x - 1, y, this) != null)
            output.Add(new Point(x - 1, y));

        //left up and down
        if (IsEmpty(x - 1, y - 1, this) != null)
            output.Add(new Point(x - 1, y - 1));

        if (IsEmpty(x - 1, y + 1, this) != null)
            output.Add(new Point(x - 1, y + 1));

        //right up and down
        if (IsEmpty(x + 1, y - 1, this) != null)
            output.Add(new Point(x + 1, y - 1));

        if (IsEmpty(x + 1, y + 1, this) != null)
            output.Add(new Point(x + 1, y + 1));

        if (HasMoved || (y != 7 && y != 0))
            return output;

        //checking from right side
        if (IsEmpty(x + 1, y, this) == true
            && IsEmpty(x + 2, y, this) == true
            && IsFriendlyRook(x + 3, y, this))
        {
            output.Add(new Point(x + 2, y));
        }

        //checking from left side
        if (IsEmpty(x - 1, y, this) == true
            && IsEmpty(x - 2, y, this) == true
            && IsEmpty(x - 3, y, this) == true
            && IsFriendlyRook(x - 4, y, this))
        {
            output.Add(new Point(x - 2, y));
        }

        return output;
    }
}