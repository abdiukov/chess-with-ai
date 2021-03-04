using System;

namespace ChessBoardAssets
{
    public struct Coordinates
    {
        public static Square[,] board = new Square[8, 8];

        public static bool? IsEmpty(int x, int y)
        {
            try
            {
                return board[x, y].piece is null;
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            };
        }
    }
}
