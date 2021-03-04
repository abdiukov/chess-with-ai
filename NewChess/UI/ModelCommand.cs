using System.Drawing;

namespace Chess
{
    public abstract class ModelCommand : ICommand<Model>
    {
        private bool success;

        public bool Success
        {
            get { return success; }
            set { success = value; }
        }
        public abstract void execute(Model model);
    }

    class StartGameCommand : ModelCommand
    {
        public override void execute(Model model)
        {
            model.Start();
        }
    }

    class SelectSquareCommand : ModelCommand
    {
        private Point coord;

        public SelectSquareCommand(Point coord) { this.coord = coord; }

        public override void execute(Model model)
        {
            Success = model.Select(coord);
        }


    }
}