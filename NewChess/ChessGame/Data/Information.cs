using System.Drawing;
using ChessGame.Model;

namespace ChessGame.Data;

public class Information : IInformation
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
            var whiteKingLocation = WhiteKingLocation;
            whiteKingLocation.X = x;
            whiteKingLocation.Y = y;
        }
        else
        {
            var blackKingLocation = BlackKingLocation;
            blackKingLocation.X = x;
            blackKingLocation.Y = y;
        }
    }
}