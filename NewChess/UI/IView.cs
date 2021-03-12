using System.Drawing;
namespace Chess
{
    public interface IView : ICommandHandler<ViewCommand>
    {
        void DrawSquare(Image piece, Point coord);
    }
}
