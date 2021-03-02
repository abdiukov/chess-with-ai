namespace Chess
{
    //LOGIC
    public interface ICommand<T>
    {
        void execute(T t);
    }
    //INTERFACE
    public interface CommandHandler<T>
    {
        void Handle(T command);
    }
}
