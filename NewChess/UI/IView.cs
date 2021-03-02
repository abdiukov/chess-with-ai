using System.Drawing;
namespace Chess
{
    public interface IView : CommandHandler<ViewCommand>
    {
        void DrawSquare(Image background, Image piece, Point coord);
    }
}
