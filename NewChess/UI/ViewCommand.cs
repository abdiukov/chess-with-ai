using System.Drawing;

namespace Chess
{
    public abstract class ViewCommand : ICommand<IView>
    {
        public abstract void execute(IView view);
    }

    public class DrawSquareCommand : ViewCommand
    {
        private Point coord;
        private Piece piece;

        public DrawSquareCommand(Point coord, Piece piece)
        {
            this.coord = coord;
            this.piece = piece;
        }

        public override void execute(IView view)
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