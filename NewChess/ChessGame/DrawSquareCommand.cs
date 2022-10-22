using ChessGame.Model;
using System.Drawing;

namespace ChessGame;
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
            pieceImage = _piece.Image;

        view.DrawSquare(pieceImage, _coordinate);
    }
}