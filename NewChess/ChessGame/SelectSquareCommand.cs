using System.Drawing;

namespace ChessGame;
internal class SelectSquareCommand : ControllerCommand
{
    private readonly Point _coordinate;

    public SelectSquareCommand(Point coordinate) { _coordinate = coordinate; }

    public override void Execute(Controller controller)
    {
        Success = controller.Select(_coordinate);
    }
}