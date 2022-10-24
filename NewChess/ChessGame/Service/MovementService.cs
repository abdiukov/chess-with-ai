using ChessGame.Model;
using System.Drawing;
using ChessGame.Data;

namespace ChessGame.Service;
public class MovementService : IMovementService
{
    private readonly IInformation _information;
    private readonly ICommandHandler<ViewCommand> _commandHandler;

    public MovementService(IInformation information, 
        ICommandHandler<ViewCommand> commandHandler)
    {
        _information = information;
        _commandHandler = commandHandler;
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
        Piece upgradedPiece = new Queen(_information.CurrentTeam);

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
        _commandHandler.Handle(new DrawSquareCommand(coordinate, piece));
    }
}