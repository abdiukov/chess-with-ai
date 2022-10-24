using ChessGame.Model;
using System.Drawing;

namespace ChessGame.Service;
public interface IMovementService
{
    public void Update(Point coordinate);
    public void Place(int col, int row, Piece piece);
    public void UpgradePawn(int x, int y);
    public void UndoMove(Point origin, Point destination);
    public void Move(Point origin, Point destination);
}