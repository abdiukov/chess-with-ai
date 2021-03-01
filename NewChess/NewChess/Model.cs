using System;
using System.Drawing;

namespace Chess
{
    public interface BoardUtilities
    {
        bool Obstructed(Point origin, Point destination);
    }


    public class Model : BoardUtilities, CommandHandler<ModelCommand>
    {
        private const int BoardRows = 8;
        private const int BoardColumns = 8;
        private CommandHandler<ViewCommand> commandHandler;
        public Square[,] board = new Square[BoardRows, BoardColumns];
        private Team currentPlayer;
        private Point? selectedSquare;

        public Model(CommandHandler<ViewCommand> commandHandler)
        {
            this.commandHandler = commandHandler;
            for (int i = 0; i < BoardRows; i++)
            {
                for (int j = 0; j < BoardColumns; j++)
                {
                    board[i, j] = new Square();
                }
            }
        }

        public void Handle(ModelCommand command) { command.execute(this); }

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
            Piece piece = board[coord.X, coord.Y].piece;
            if ((piece != null) && (piece.Team == currentPlayer))
            {
                selectedSquare = coord;
                return true;
            }
            else if (selectedSquare != null)
            {
                bool success = Move(selectedSquare.Value, coord);
                selectedSquare = null;
                return success;
            }
            return false;
        }

        private bool Move(Point origin, Point destination)
        {
            Piece mover = board[origin.X, origin.Y].piece;
            Move move = mover.CanMove(this, origin, destination);
            //checks if its a pawn and if it is trying to move, dont allow
            //if (mover.ToString() == "Chess.Pawn")
            //{

            //}
            //DoTheMove:
            if (move != null)
            {
                move.Execute();
                board[destination.X, destination.Y].piece = mover;
                board[origin.X, origin.Y].piece = null;
                Update(origin);
                Update(destination);
                currentPlayer = currentPlayer == Team.White ? Team.Black : Team.White;
                return true;
            }
            return false;
        }

        public bool pieceIsNull(Point destination)
        {
            Piece piece = board[destination.X, destination.Y].piece;
            if (piece == null)
            {
                return true;
            }
            return false;
        }


        public bool Obstructed(Point origin, Point destination)
        {
            Point move = origin;
            Point oneBefore = destination;
            int xDir = Math.Sign(destination.X - origin.X);
            int yDir = Math.Sign(destination.Y - origin.Y);
            oneBefore.X -= xDir;
            oneBefore.Y -= yDir;
            while (move != oneBefore)
            {
                move.X += xDir;
                move.Y += yDir;
                if (board[move.X, move.Y].piece != null) { return true; }
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
                //modified 
                Place(row, i, new Pawn(team));
            }
        }

        private void Place(int col, int row, Piece piece)
        {
            board[row, col].piece = piece;
            Update(new Point(row, col));
        }

        private void Update(Point coord)
        {
            Piece piece = board[coord.X, coord.Y].piece;
            commandHandler.Handle(new DrawSquareCommand(coord, piece));
        }
    }
}
