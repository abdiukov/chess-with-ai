namespace ChessGame;

public abstract class ViewCommand : ICommand<IView>
{
    public abstract void Execute(IView view);
}