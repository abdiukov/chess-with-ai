namespace ChessGame;
public class StartGameCommand : ControllerCommand
{
    public override void Execute(Controller controller)
    {
        controller.Start();
    }
}