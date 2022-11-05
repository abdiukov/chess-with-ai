using ChessGame.Model;
using System.Drawing;

namespace ChessGame;
public interface IGameSettings
{
    bool PlayAgainstAi { get; set; }
    Team CurrentTeam { get; set; }
    Point WhiteKingLocation { get; set; }
    Point BlackKingLocation { get; set; }
    Point GetMyKingLocation();
    void UpdateKingLocation(int x, int y);
}