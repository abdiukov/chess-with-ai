using System.Drawing;
using ChessGame.Model;

namespace ChessGame.Data;

public abstract class Information
{
    public static bool PlayAgainstAi { get; set; }
    public static Team CurrentTeam { get; set; }
    private static Point _whiteKingLocation;
    private static Point _blackKingLocation;
    private static bool _hasWhiteKingEverMoved;
    private static bool _hasBlackKingEverMoved;

    public static void SetDefaultValues()
    {
        _whiteKingLocation = new Point(4, 7);
        _blackKingLocation = new Point(4, 0);
        _hasWhiteKingEverMoved = false;
        _hasBlackKingEverMoved = false;
    }

    public static void UpdateKingEverMoved()
    {
        if (CurrentTeam == Team.White)
        {
            _hasWhiteKingEverMoved = true;
        }
        else
        {
            _hasBlackKingEverMoved = true;
        }
    }

    public static bool HasMyKingMovedBefore()
    {
        return CurrentTeam == Team.White ? _hasWhiteKingEverMoved : _hasBlackKingEverMoved;
    }

    public static Point GetMyKingLocation()
    {
        return CurrentTeam == Team.White ? _whiteKingLocation : _blackKingLocation;
    }
    public static void UpdateKingLocation(int x, int y)
    {
        if (CurrentTeam == Team.White)
        {
            _whiteKingLocation.X = x;
            _whiteKingLocation.Y = y;
        }
        else
        {
            _blackKingLocation.X = x;
            _blackKingLocation.Y = y;
        }
    }

}