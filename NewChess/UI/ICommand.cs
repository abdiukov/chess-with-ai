namespace Chess
{
    public interface ICommand<T>
    {
        void Execute(T t);
    }
    public interface ICommandHandler<T>
    {
        void Handle(T command);
    }
}
