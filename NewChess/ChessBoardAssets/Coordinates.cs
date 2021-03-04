using GameInfo;
using System;

namespace ChessBoardAssets
{
    public struct Coordinates
    {
        public static Square[,] board = new Square[8, 8];

        private static bool ExitNextLoop = false;

        public static bool? IsEmpty(int x, int y)
        {
            try
            {
                if (ExitNextLoop == true)
                {
                    ExitNextLoop = false;
                    return null;
                }
                else if (board[x, y].piece is null)
                {
                    return true;
                }
                else if (board[x, y].piece.Team != Information.currentPlayer)
                {
                    ExitNextLoop = true;
                    return true;
                }

                return false;
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            };
        }
    }
}
