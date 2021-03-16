using System.Drawing;

namespace GameInfo
{
    public enum Team { White, Black };
    public abstract class Information
    {
        public static Team currentPlayer;

        private static Point WhiteKingLocation = new(4, 7);

        private static Point BlackKingLocation = new(4, 0);

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

        public static void UndoUpdateKingLocation(int x, int y)
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
