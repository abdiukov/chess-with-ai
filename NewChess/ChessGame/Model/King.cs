using System.Collections.Generic;
using System.Drawing;
using ChessGame.Data;

namespace ChessGame.Model;

public class King : Piece
{
    public King(Team team)
        : base(team, "King") { }

    public override IList<Point?> GetMoves(int x, int y)
    {
        List<Point?> output = new();

        //move right up and down -  from the white side perspective
        //so for example from the black perspective, up would be down, down would be up etc

        //right = x+1
        //left = x-1
        //up y-1
        //down y+1

        //up and down
        if (IsEmpty(x, y - 1, this) != null) { output.Add(new Point(x, y - 1)); }

        if (IsEmpty(x, y + 1, this) != null) { output.Add(new Point(x, y + 1)); }

        //left and right
        if (IsEmpty(x + 1, y, this) != null) { output.Add(new Point(x + 1, y)); }

        if (IsEmpty(x - 1, y, this) != null) { output.Add(new Point(x - 1, y)); }

        //left up
        if (IsEmpty(x - 1, y - 1, this) != null) { output.Add(new Point(x - 1, y - 1)); }

        //left down
        if (IsEmpty(x - 1, y + 1, this) != null) { output.Add(new Point(x - 1, y + 1)); }

        //right up
        if (IsEmpty(x + 1, y - 1, this) != null) { output.Add(new Point(x + 1, y - 1)); }

        //right down
        if (IsEmpty(x + 1, y + 1, this) != null) { output.Add(new Point(x + 1, y + 1)); }

        //TODO: Implement
        //if (Information.HasMyKingMovedBefore() || (y != 7 && y != 0)) return output;

        //checking from right side
        if (IsEmpty(x + 1, y, this) == true && IsEmpty(x + 2, y, this) == true
                                            && IsFriendlyRook(x + 3, y, this))
        {
            output.Add(new Point(x + 2, y));
        }

        //checking from left side
        if (IsEmpty(x - 1, y, this) == true && IsEmpty(x - 2, y, this) == true &&
            IsEmpty(x - 3, y, this) == true && IsFriendlyRook(x - 4, y, this))
        {
            output.Add(new Point(x - 2, y));
        }

        return output;
    }
}