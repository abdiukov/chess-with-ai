using System.Drawing;

namespace ChessGame;
public interface IController 
{
    void Start();
    bool Select(Point coordinate);
    void ProcessMouseClickMove(Point coordinate);
}