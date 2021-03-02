using System.Drawing;
namespace Chess
{
    public interface IView : CommandHandler<ViewCommand>
    {
        void DrawSquare(Image piece, Point coord);
    }
}
