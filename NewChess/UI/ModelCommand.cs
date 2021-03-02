namespace Chess
{
    public abstract class ModelCommand : ICommand<Model>
    {

        public abstract void execute(Model model);
    }

    class StartGameCommand : ModelCommand
    {
        public override void execute(Model model)
        {
            model.Start();
        }
    }
}