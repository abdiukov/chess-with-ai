using System.Collections.Generic;
using System.Drawing;

namespace ChessGame.Model
{
    public class Knight : Piece
    {
        public Knight(Team team)
            : base(team, "Knight") { }

        public override List<Point?> GetMoves(int x, int y)
        {
            List<Point?> output = new();

            //up left

            if (IsEmpty(x - 1, y - 2,this) != null) { output.Add(new Point(x - 1, y - 2)); }
            //up right

            if (IsEmpty(x + 1, y - 2,this) != null) { output.Add(new Point(x + 1, y - 2)); }

            //down left

            if (IsEmpty(x - 1, y + 2,this) != null) { output.Add(new Point(x - 1, y + 2)); }

            //down right

            if (IsEmpty(x + 1, y + 2,this) != null) { output.Add(new Point(x + 1, y + 2)); }

            //left up

            if (IsEmpty(x - 2, y - 1,this) != null) { output.Add(new Point(x - 2, y - 1)); }

            //left down

            if (IsEmpty(x - 2, y + 1,this) != null) { output.Add(new Point(x - 2, y + 1)); }

            //right up
            if (IsEmpty(x + 2, y - 1,this) != null) { output.Add(new Point(x + 2, y - 1)); }

            //right down
            if (IsEmpty(x + 2, y + 1,this) != null) { output.Add(new Point(x + 2, y + 1)); }

            return output;
        }


    }
}
