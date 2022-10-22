namespace ChessGame;
public abstract class ControllerCommand : ICommand<Controller>
{
    public bool Success { get; set; }
    public abstract void Execute(Controller controller);
}