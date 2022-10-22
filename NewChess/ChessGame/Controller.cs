using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ChessEngine.Engine;
using ChessGame.Model;
using ChessGame.Service;
using Information = ChessGame.Data.Information;

namespace ChessGame;

public class Controller : ICommandHandler<ControllerCommand>
{
    private const int BoardRows = 8;
    private const int BoardColumns = 8;
    private readonly ICommandHandler<ViewCommand> _commandHandler;
    private Point? _selectedSquare;
    private Information _information;
    private readonly ChessCoreEngineAdapterService _adapter = new();

    public Controller(ICommandHandler<ViewCommand> commandHandler)
    {
        _commandHandler = commandHandler;

        for (var i = 0; i < BoardRows; i++)
        {
            for (var j = 0; j < BoardColumns; j++)
            {
                Coordinates.Board[i, j] = new Square();
            }
        }
    }

    public void Handle(ControllerCommand command) { command.Execute(this); }

    //CODE TO START GAME UNDER DIFFERENT CONDITIONS

    public void PlayAsBlackAgainstAi()
    {
        _information = new();
        _information.PlayAgainstAi = true;
        _adapter.StartGame(ChessPieceColor.Black);

        var outputFromAi = _adapter.MakeEngineMove();
        ProcessAiOutput(outputFromAi);
        _information.CurrentTeam = Team.Black;
    }

    public void StartAsWhiteAgainstAi()
    {
        _information = new();
        _information.PlayAgainstAi = true;
        _adapter.StartGame();
        _information.CurrentTeam = Team.White;
    }

    public void StartAsWhiteAgainstPlayer()
    {
        _information = new();
        _information.PlayAgainstAi = false;
        _information.CurrentTeam = Team.White;
    }

    //CODE TO INITIALISE THE PIECES

    public void Start()
    {
        InitPawns(6, Team.White);
        InitBackRow(7, Team.White);
        InitPawns(1, Team.Black);
        InitBackRow(0, Team.Black);
        UpdateAll();
    }

    private void UpdateAll()
    {
        for (var i = 0; i < BoardRows; i++)
        {
            for (var j = 0; j < BoardColumns; j++)
            {
                Update(new Point(i, j));
            }
        }
    }

    private void InitPawns(int row, Team team)
    {
        for (var i = 0; i < 8; i++)
            Place(row, i, new Pawn(team));
    }

    private void InitBackRow(int row, Team team)
    {
        Place(row, 0, new Rook(team));
        Place(row, 1, new Knight(team));
        Place(row, 2, new Bishop(team));
        Place(row, 3, new Queen(team));
        Place(row, 4, new King(team));
        Place(row, 5, new Bishop(team));
        Place(row, 6, new Knight(team));
        Place(row, 7, new Rook(team));
    }

    //RESPONSE TO USER INPUT CODE

    public bool Select(Point coordinate)
    {
        try
        {
            var piece = Coordinates.Board[coordinate.X, coordinate.Y].Piece;

            if (piece != null && piece.Team == _information.CurrentTeam)
            {
                _selectedSquare = coordinate;
                Program.GameWindow.PossibleMoves = piece.GetMoves(coordinate.X, coordinate.Y);
                return true;
            }

            if (Program.GameWindow.PossibleMoves.Contains(coordinate))
            {
                Program.GameWindow.PossibleMoves.Clear();
                ProcessMouseClickMove(coordinate);
                _selectedSquare = null;
                return true;
            }
        }
        catch (IndexOutOfRangeException) { }
        Program.GameWindow.PossibleMoves.Clear();
        return false;
    }


    public void ProcessMouseClickMove(Point coordinate)
    {
        var kingIsCastlingLeft = false;
        var kingIsCastlingRight = false;
        var movingPieceIsKing = false;
        List<Point?> forbiddenSquares = new();

        Move(_selectedSquare.Value, coordinate);

        //if the moving piece is King
        if (Coordinates.Board[coordinate.X, coordinate.Y].Piece is King)
        {
            movingPieceIsKing = true;
            forbiddenSquares.Add(new Point(coordinate.X, coordinate.Y));

            //if the king is castling
            if (Math.Abs(_selectedSquare.Value.X - coordinate.X) == 2)
                switch (coordinate.X)
                {
                    //add the squares in between castling to "forbidden squares" - these squares cannot be checked by enemy
                    case 2:
                        kingIsCastlingLeft = true;
                        forbiddenSquares.Add(coordinate with { X = 3 });
                        forbiddenSquares.Add(coordinate with { X = 4 });
                        break;
                    case 6:
                        kingIsCastlingRight = true;
                        forbiddenSquares.Add(coordinate with { X = 4 });
                        forbiddenSquares.Add(coordinate with { X = 5 });
                        break;
                }
        }
        //otherwise, add king to the forbidden squares - the king cannot be checked
        else
            forbiddenSquares.Add(_information.GetMyKingLocation());

        //check every move to see whether the enemy can check either forbidden squares
        //if the enemy can, undo the move

        for (var i = 0; i <= 7; i++)
        {
            for (var j = 0; j <= 7; j++)
            {
                var toCheck = Coordinates.Board[i, j].Piece;
                if (toCheck == null)
                    continue;

                //the piece has to be from the opposite team
                //the piece should be able to check one of the forbidden squares
                if (toCheck.Team == _information.CurrentTeam)
                    continue;

                var getMoves = toCheck.GetMoves(i, j);

                if (!getMoves.Intersect(forbiddenSquares).Any())
                    continue;

                UndoMove(_selectedSquare.Value, coordinate);
                return;
            }
        }

        if (Coordinates.Board[coordinate.X, coordinate.Y].Piece is Pawn)
            if (coordinate.Y is 0 or 7)
                UpgradePawn(coordinate.X, coordinate.Y);

        if (movingPieceIsKing)
        {
            var king = Coordinates.Board[coordinate.X, coordinate.Y].Piece as King;
            king.HasMoved = true;

            //once we have moved, update the position of the king
            _information.UpdateKingLocation(coordinate.X, coordinate.Y);

            //also if castling has been done, move the rook
            if (kingIsCastlingLeft)
                Move(_selectedSquare.Value with { X = 0 }, _selectedSquare.Value with { X = 3 });

            else if (kingIsCastlingRight)
                Move(_selectedSquare.Value with { X = 7 }, _selectedSquare.Value with { X = 5 });

        }

        _information.CurrentTeam = _information.CurrentTeam == Team.White ? Team.Black : Team.White;

        //logic if it is an ai
        if (_information.PlayAgainstAi)
            DoAiMove(_selectedSquare.Value.X, _selectedSquare.Value.Y, coordinate.X, coordinate.Y);

    }


    //RESPONSE TO AI

    private void DoAiMove(int moverX, int moverY, int destinationX, int destinationY)
    {
        var outputFromAi = _adapter.MakeMove((byte)moverX, (byte)moverY, (byte)destinationX, (byte)destinationY);

        switch (outputFromAi.Length)
        {
            case 4:
                ProcessAiOutput(outputFromAi);
                _information.CurrentTeam = _information.CurrentTeam == Team.White ? Team.Black : Team.White;
                break;
            case > 4:
                ProcessAiOutput(outputFromAi[..4]);
                MessageBox.Show(outputFromAi[4..], @"Game over!");
                _information.CurrentTeam = _information.CurrentTeam == Team.White ? Team.Black : Team.White;
                break;
            default:
                MessageBox.Show(@"Move is invalid. Please try again.");
                break;
        }
    }

    private void ProcessAiOutput(string outputFromAi)
    {
        var x1 = int.Parse(outputFromAi[0].ToString());
        var y1 = int.Parse(outputFromAi[1].ToString());
        var x2 = int.Parse(outputFromAi[2].ToString());
        var y2 = int.Parse(outputFromAi[3].ToString());

        Point origin = new(x1, y1);
        Point destination = new(x2, y2);

        Move(origin, destination);

        if (Math.Abs(x1 - x2) != 2 || Coordinates.Board[x2, y2].Piece is not King)
            return;

        switch (x2)
        {
            case 2:
                //left side
                Move(new Point(0, y2), new Point(3, y2));
                break;
            case 6:
                //right side
                Move(new Point(7, y2), new Point(5, y2));
                break;
        }
    }

    //MOVEMENT CODE

    private Piece _savedPiece;

    private void Move(Point origin, Point destination)
    {
        _savedPiece = Coordinates.Board[destination.X, destination.Y].Piece;

        var mover = Coordinates.Board[origin.X, origin.Y].Piece;
        Coordinates.Board[destination.X, destination.Y].Piece = mover;
        Coordinates.Board[origin.X, origin.Y].Piece = null;
        Update(origin);
        Update(destination);
    }

    private void UndoMove(Point origin, Point destination)
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

    //CODE TO UPDATE THE BOARD
    private void Place(int col, int row, Piece piece)
    {
        Coordinates.Board[row, col].Piece = piece;
        Update(new Point(row, col));
    }

    private void Update(Point coordinate)
    {
        var piece = Coordinates.Board[coordinate.X, coordinate.Y].Piece;
        _commandHandler.Handle(new DrawSquareCommand(coordinate, piece));
    }
}