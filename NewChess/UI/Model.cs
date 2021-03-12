using ChessBoardAssets;
using GameInfo;
using LogicLayer;
using System;
using System.Drawing;

namespace Chess
{

    public class Model : ICommandHandler<ModelCommand>
    {
        private const int BoardRows = 8;
        private const int BoardColumns = 8;
        private readonly ICommandHandler<ViewCommand> commandHandler;
        private Point? selectedSquare;
        private readonly Controller contr = new Controller();
        public Model(ICommandHandler<ViewCommand> commandHandler)
        {
            Information.currentPlayer = Team.White;
            this.commandHandler = commandHandler;
            for (int i = 0; i < BoardRows; i++)
            {
                for (int j = 0; j < BoardColumns; j++)
                {
                    Coordinates.board[i, j] = new Square();
                }
            }
        }

        public void Handle(ModelCommand command) { command.Execute(this); }

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
            Console.WriteLine("Updating all;");
            for (int i = 0; i < BoardRows; i++)
            {
                for (int j = 0; j < BoardColumns; j++)
                {
                    Update(new Point(i, j));
                }
            }
        }

        public bool Select(Point coord)
        {
            Piece piece = Coordinates.board[coord.X, coord.Y].piece;

            if (piece != null && piece.Team == Information.currentPlayer)
            {
                selectedSquare = coord;
                GUIView.possibleMoves = contr.GetPossibleMoves(piece, coord.X, coord.Y);
                return true;
            }
            else if (GUIView.possibleMoves.Contains(coord))
            {
                bool success = Move(selectedSquare.Value, coord);
                selectedSquare = null;
                GUIView.possibleMoves.Clear();
                return success;
            }
            else
            {
                GUIView.possibleMoves.Clear();
                return false;
            }
        }


        private bool Move(Point origin, Point destination)
        {
            Piece mover = Coordinates.board[origin.X, origin.Y].piece;
            if (GUIView.possibleMoves.Count > 0)
            {
                Coordinates.board[destination.X, destination.Y].piece = mover;
                Coordinates.board[origin.X, origin.Y].piece = null;
                Update(origin);
                Update(destination);
                Information.currentPlayer = Information.currentPlayer == Team.White ? Team.Black : Team.White;
                return true;
            }
            return false;
        }



        private void InitBackRow(int row, Team team)
        {
            //changed the row a bit, now it works
            Place(row, 0, new Rook(team));
            Place(row, 1, new Knight(team));
            Place(row, 2, new Bishop(team));
            Place(row, 3, new Queen(team));
            Place(row, 4, new King(team));
            Place(row, 5, new Bishop(team));
            Place(row, 6, new Knight(team));
            Place(row, 7, new Rook(team));
        }

        private void InitPawns(int row, Team team)
        {
            for (int i = 0; i < 8; i++)
            {
                Place(row, i, new Pawn(team));
            }
        }

        private void Place(int col, int row, Piece piece)
        {
            Coordinates.board[row, col].piece = piece;
            Update(new Point(row, col));
        }

        private void Update(Point coord)
        {
            Piece piece = Coordinates.board[coord.X, coord.Y].piece;
            commandHandler.Handle(new DrawSquareCommand(coord, piece));
        }
    }
}
