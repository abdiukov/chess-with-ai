using ChessGame.Model;
using System.Drawing;

namespace ChessGame.Service;
public interface IMovementService
{
    public IGameSettings GameSettings { get; set; }
    void Update(Point coordinate);
    void Place(int col, int row, Piece piece);
    void UpgradePawn(int x, int y);
    void UndoMove(Point origin, Point destination);
    void Move(Point origin, Point destination);
}