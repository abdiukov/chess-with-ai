using GameBoard;
using System.Drawing;

namespace Chess
{
    public abstract class ViewCommand : ICommand<IView>
    {
        public abstract void Execute(IView view);
    }

    public class DrawSquareCommand : ViewCommand
    {
        private readonly Point coord;
        private readonly Piece piece;

        public DrawSquareCommand(Point coord, Piece piece)
        {
            this.coord = coord;
            this.piece = piece;
        }

        public override void Execute(IView view)
        {
            Image pieceImage = null;
            if (piece != null)
            {
                pieceImage = piece.image;
            }
            view.DrawSquare(pieceImage, coord);
        }
    }
}