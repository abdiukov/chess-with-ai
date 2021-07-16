using Model;
using System.Drawing;

namespace GameInformation
{
    public abstract class Information
    {
        public static bool PlayAgainstAI { get; set; }
        public static Team CurrentTeam { get; set; }
        private static Point WhiteKingLocation;
        private static Point BlackKingLocation;
        private static bool hasWhiteKingEverMoved;
        private static bool hasBlackKingEverMoved;

        public static void SetDefaultValues()
        {
            WhiteKingLocation = new(4, 7);
            BlackKingLocation = new(4, 0);
            hasWhiteKingEverMoved = false;
            hasBlackKingEverMoved = false;
        }

        public static void UpdateKingEverMoved()
        {
            if (CurrentTeam == Team.White)
            {
                hasWhiteKingEverMoved = true;
            }
            else
            {
                hasBlackKingEverMoved = true;
            }
        }

        public static bool HasMyKingMovedBefore()
        {
            if (CurrentTeam == Team.White)
            {
                return hasWhiteKingEverMoved;
            }
            else
            {
                return hasBlackKingEverMoved;
            }
        }

        public static Point GetMyKingLocation()
        {
            if (CurrentTeam == Team.White)
            {
                return WhiteKingLocation;
            }
            else
            {
                return BlackKingLocation;
            }
        }
        public static void UpdateKingLocation(int x, int y)
        {
            if (CurrentTeam == Team.White)
            {
                WhiteKingLocation.X = x;
                WhiteKingLocation.Y = y;
            }
            else
            {
                BlackKingLocation.X = x;
                BlackKingLocation.Y = y;
            }
        }

    }
}
