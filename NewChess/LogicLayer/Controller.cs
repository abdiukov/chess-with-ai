using ChessBoardAssets;
using Movement;
using System.Collections.Generic;
using System.Drawing;

namespace LogicLayer
{
    public class Controller
    {
        private Team currentPlayer;
        private Move moves;

        public void Moves(Point origin)
        {
            //moves should retrieve all coordinates
            //moves should retieve the name of piece

            List<Move> AllMoves = GetAllMoves();

            foreach (var item in AllMoves)
            {
                //
            }

            //output = List<Point> destination;
            //coordinates need to be stored somewhere safe
            return;
        }

        private List<Move> GetAllMoves() //supply name of iece
        {
            //should supply the moves to the getallmoves
            //filter the moves for the specific piece
            List<Move> movess = new List<Move>();
            movess.Add(moves);
            return movess;
        }
    }
}
