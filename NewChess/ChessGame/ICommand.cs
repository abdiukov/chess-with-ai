namespace ChessGame;

public interface ICommand<in T>
{
    void Execute(T t);
}