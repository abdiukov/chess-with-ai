using GameInfo;
using System.Drawing;

namespace ChessBoardAssets
{
    public abstract class Piece
    {
        public Team Team;
        public Image image;

        public Piece(Team team, string file)
        {
            Team = team;
            image = Image.FromFile(file + "_" + team.ToString()[0] + ".png");
        }
    }

    public class Rook : Piece
    {
        public Rook(Team team)
            : base(team, "Rook")
        {
        }
    }

    public class Pawn : Piece
    {
        public Pawn(Team team)
            : base(team, "Pawn")
        {
        }


    }

    public class Bishop : Piece
    {
        public Bishop(Team team)
            : base(team, "Bishop")
        {
        }
    }

    public class Knight : Piece
    {
        public Knight(Team team)
            : base(team, "Knight")
        {
        }
    }

    public class King : Piece
    {
        public King(Team team)
            : base(team, "King")
        {
        }
    }

    public class Queen : Piece
    {
        public Queen(Team team)
            : base(team, "Queen")
        {
        }
    }
}
