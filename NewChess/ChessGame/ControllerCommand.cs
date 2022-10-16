using System.Drawing;

namespace ChessGame;

public abstract class ControllerCommand : ICommand<Controller>
{
    public bool Success { get; set; }
    public abstract void Execute(Controller controller);
}

internal class StartGameCommand : ControllerCommand
{
    public override void Execute(Controller controller)
    {
        controller.Start();
    }
}

internal class SelectSquareCommand : ControllerCommand
{
    private readonly Point _coordinate;

    public SelectSquareCommand(Point coordinate) { _coordinate = coordinate; }

    public override void Execute(Controller controller)
    {
        Success = controller.Select(_coordinate);
    }
}