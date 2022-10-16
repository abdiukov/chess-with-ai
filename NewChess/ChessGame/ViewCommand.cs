using System.Drawing;
using ChessGame.Model;

namespace ChessGame;

public abstract class ViewCommand : ICommand<IView>
{
    public abstract void Execute(IView view);
}

public class DrawSquareCommand : ViewCommand
{
    private readonly Point _coordinate;
    private readonly Piece _piece;

    public DrawSquareCommand(Point coordinate, Piece piece)
    {
        _coordinate = coordinate;
        _piece = piece;
    }

    public override void Execute(IView view)
    {
        Image pieceImage = null;
        if (_piece != null)
        {
            pieceImage = _piece.Image;
        }
        view.DrawSquare(pieceImage, _coordinate);
    }
}