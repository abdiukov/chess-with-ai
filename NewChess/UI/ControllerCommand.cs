using System.Drawing;

namespace View
{
    public abstract class ControllerCommand : ICommand<Controller>
    {
        public bool Success { get; set; }
        public abstract void Execute(Controller controller);
    }

    class StartGameCommand : ControllerCommand
    {
        public override void Execute(Controller controller)
        {
            controller.Start();
        }
    }

    class SelectSquareCommand : ControllerCommand
    {
        private Point coord;

        public SelectSquareCommand(Point coord) { this.coord = coord; }

        public override void Execute(Controller controller)
        {
            Success = controller.Select(coord);
        }
    }
}