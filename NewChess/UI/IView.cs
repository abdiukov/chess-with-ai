using System.Drawing;
namespace View
{
    public interface IView : ICommandHandler<ViewCommand>
    {
        void DrawSquare(Image piece, Point coord);
    }
}
