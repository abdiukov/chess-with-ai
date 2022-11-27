using ChessGame.Model;
using System.Drawing;

namespace ChessGame.Service;
public class MovementService : IMovementService
{
    public IGameSettings GameSettings { get; set; }

    public MovementService(IGameSettings gameSettings)
    {
        GameSettings = gameSettings;
    }

    private Piece _savedPiece;

    public void Move(Point origin, Point destination)
    {
        _savedPiece = Coordinates.Board[destination.X, destination.Y].Piece;

        var mover = Coordinates.Board[origin.X, origin.Y].Piece;
        Coordinates.Board[destination.X, destination.Y].Piece = mover;
        Coordinates.Board[origin.X, origin.Y].Piece = null;
        Update(origin);
        Update(destination);
    }

    public void UndoMove(Point origin, Point destination)
    {
        Coordinates.Board[origin.X, origin.Y].Piece = Coordinates.Board[destination.X, destination.Y].Piece;
        Coordinates.Board[destination.X, destination.Y].Piece = _savedPiece;
        Update(origin);
        Update(destination);
    }

    public void UpgradePawn(int x, int y)
    {
        Piece upgradedPiece = new Queen(GameSettings.CurrentTeam);

        Coordinates.Board[x, y].Piece = upgradedPiece;

        Update(new Point(x, y));
    }

    public void Place(int col, int row, Piece piece)
    {
        Coordinates.Board[row, col].Piece = piece;
        Update(new Point(row, col));
    }

    public void Update(Point coordinate)
    {
        var piece = Coordinates.Board[coordinate.X, coordinate.Y].Piece;
        DrawSquare(coordinate, piece);
    }
    public void DrawSquare(Point coordinate, Piece piece)
    {
        Image pieceImage = null;

        if (piece != null)
            pieceImage = piece.Image;

        Program.GameWindow.DrawSquare(pieceImage, coordinate);
    }
}