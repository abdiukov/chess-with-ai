using System.Drawing;

namespace ChessGame.Model;

public enum Team { White, Black }
public abstract class Piece
{
    public Team Team;
    public Image Image;

    protected Piece(Team team, string file)
    {
        Team = team;
        Image = Image.FromFile("assets\\" + file + "_" + team.ToString()[0] + ".png");
    }
}

public class Rook : Piece
{
    public Rook(Team team)
        : base(team, "Rook") { }
}

public class Pawn : Piece
{
    public Pawn(Team team)
        : base(team, "Pawn") { }
}

public class Bishop : Piece
{
    public Bishop(Team team)
        : base(team, "Bishop") { }
}

public class Knight : Piece
{
    public Knight(Team team)
        : base(team, "Knight") { }
}

public class King : Piece
{
    public King(Team team)
        : base(team, "King") { }
}

public class Queen : Piece
{
    public Queen(Team team)
        : base(team, "Queen") { }
}