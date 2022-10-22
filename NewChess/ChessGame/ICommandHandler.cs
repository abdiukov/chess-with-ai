namespace ChessGame;
public interface ICommandHandler<in T>
{
    void Handle(T command);
}