using System.Collections.Generic;
using System.Drawing;

namespace ChessGame.Model;
public class Knight : Piece
{
    public Knight(Team team)
        : base(team, "Knight") { }

    public override List<Point?> GetMoves(int x, int y)
    {
        var output = new List<Point?>();

        //up right and left
        if (IsEmpty(x + 1, y - 2, this) != null)
            output.Add(new Point(x + 1, y - 2));

        if (IsEmpty(x - 1, y - 2, this) != null)
            output.Add(new Point(x - 1, y - 2));

        //down right and left
        if (IsEmpty(x + 1, y + 2, this) != null)
            output.Add(new Point(x + 1, y + 2));

        if (IsEmpty(x - 1, y + 2, this) != null)
            output.Add(new Point(x - 1, y + 2));

        //left up and down
        if (IsEmpty(x - 2, y - 1, this) != null)
            output.Add(new Point(x - 2, y - 1));

        if (IsEmpty(x - 2, y + 1, this) != null)
            output.Add(new Point(x - 2, y + 1));

        //right up and down
        if (IsEmpty(x + 2, y - 1, this) != null)
            output.Add(new Point(x + 2, y - 1));

        if (IsEmpty(x + 2, y + 1, this) != null)
            output.Add(new Point(x + 2, y + 1));

        return output;
    }
}