namespace ChessGame;

public interface ICommand<in T>
{
    void Execute(T t);
}
public interface ICommandHandler<in T>
{
    void Handle(T command);
}