using System.Drawing;

namespace ChessGame;

public interface IView : ICommandHandler<ViewCommand>
{
    void DrawSquare(Image piece, Point coordinate);
}