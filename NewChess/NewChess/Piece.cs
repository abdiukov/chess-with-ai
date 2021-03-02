using System.Drawing;

namespace Chess
{
    public class Square
    {
        public static System.Drawing.Image background;
        public Piece piece;

        public Square()
        {
            if (background == null)
            {
                background = Image.FromFile("Empty.png");
            }
        }
    }

    public enum Team { White, Black };

    public abstract class Piece
    {
        private Team team;
        //protected List<Move> moves;
        public Image image;

        public Piece(Team team, string file)
        {
            this.team = team;
            image = Image.FromFile(file + "_" + team.ToString().ToCharArray()[0] + ".png");
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
