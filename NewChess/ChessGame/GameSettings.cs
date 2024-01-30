using System.Drawing;
using ChessGame.Model;

namespace ChessGame;

public class GameSettings : IGameSettings
{
    public bool PlayAgainstAi { get; set; } = false;
    public Team CurrentTeam { get; set; } = Team.White;
    public Point WhiteKingLocation { get; set; } = new(4, 7);
    public Point BlackKingLocation { get; set; } = new(4, 0);

    public Point GetMyKingLocation()
        => CurrentTeam == Team.White ? WhiteKingLocation : BlackKingLocation;

    public void UpdateKingLocation(int x, int y)
    {
        if (CurrentTeam == Team.White)
        {
            WhiteKingLocation = new Point(x, y);
        }
        else
        {
            BlackKingLocation = new Point(x, y);
        }
    }
}