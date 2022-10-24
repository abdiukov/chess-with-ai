using ChessGame.Model;
using System.Drawing;

namespace ChessGame;
public interface IController : ICommandHandler<ControllerCommand>
{
    void Handle(ControllerCommand command);
    void Start();
    bool Select(Point coordinate);
    void ProcessMouseClickMove(Point coordinate);
}