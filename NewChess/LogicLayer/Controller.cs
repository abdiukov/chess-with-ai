using ChessBoardAssets;
using Movement;

namespace LogicLayer
{
    public class Controller
    {
        private Team currentPlayer;
        private Move moves;

        public void GetPossibleMoves(Piece piece)
        {
            switch (piece)
            {
                case Pawn:
                    GetMovesPawn(piece);
                    break;
                case Knight:
                    GetMovesKnight(piece);
                    break;
                case Rook:
                    GetMovesRook(piece);
                    break;
                case Bishop:
                    GetMovesBishop(piece);
                    break;
                case King:
                    GetMovesKing(piece);
                    break;
                case Queen:
                    GetMovesQueen(piece);
                    break;
            }

            //returns the highlighted squares

            //the program then looks at these highlighted squares and moves there
        }



        private void GetMovesPawn(Piece piece)
        {

        }

        private void GetMovesRook(Piece piece)
        {
        }

        private void GetMovesKnight(Piece piece)
        {
        }

        private void GetMovesBishop(Piece piece)
        {
        }

        private void GetMovesKing(Piece piece)
        {
        }

        private void GetMovesQueen(Piece piece)
        {
        }


    }
}
