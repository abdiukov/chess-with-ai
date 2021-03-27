using System.Drawing;

namespace GameInfo
{
    public enum Team { White, Black };
    public abstract class Information
    {
        public static bool PlayAgainstAI = true;

        public static Team currentPlayer;

        private static Point WhiteKingLocation = new(4, 7);

        private static Point BlackKingLocation = new(4, 0);

        private static bool hasWhiteKingEverMoved = false;

        private static bool hasBlackKingEverMoved = false;

        public static void SetDefaultValues()
        {
            WhiteKingLocation = new(4, 7);
            BlackKingLocation = new(4, 0);
            hasWhiteKingEverMoved = false;
            hasBlackKingEverMoved = false;
        }



        public static void UpdateKingEverMoved()
        {
            if (currentPlayer != Team.White)
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
            if (currentPlayer == Team.White)
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
            if (currentPlayer != Team.White)
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
            if (currentPlayer != Team.White)
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
