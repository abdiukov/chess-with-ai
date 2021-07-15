using System.Drawing;

namespace Chess
{
    public abstract class ModelCommand : ICommand<Model>
    {
        public bool Success { get; set; }
        public abstract void Execute(Model model);
    }

    class StartGameCommand : ModelCommand
    {
        public override void Execute(Model model)
        {
            model.Start();
        }
    }

    class SelectSquareCommand : ModelCommand
    {
        private Point coord;

        public SelectSquareCommand(Point coord) { this.coord = coord; }

        public override void Execute(Model model)
        {
            Success = model.Select(coord);
        }
    }
}