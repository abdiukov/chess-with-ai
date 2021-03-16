using ChessBoardAssets;
using GameInfo;
using LogicLayer;
using System;
using System.Collections.Generic;
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
            try
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

                    GUIView.possibleMoves.Clear();


                    //update king's location
                    switch (Coordinates.board[coord.X, coord.Y].piece)
                    {
                        case King:
                            Information.UpdateKingLocation(coord.X, coord.Y);
                            Information.UpdateKingEverMoved();
                            break;
                    }


                    for (int i = 0; i <= 7; i++)
                    {
                        for (int j = 0; j <= 7; j++)
                        {
                            Piece tocheck = Coordinates.board[i, j].piece;
                            if (tocheck != null)
                            {
                                //by that point the team has been switched, that is why we are checking current player team
                                //in reality we are checking opposing team, whether the opposing team can eat my king
                                if (tocheck.Team == Information.currentPlayer)
                                {
                                    List<Point?> getMoves = contr.GetPossibleMoves(tocheck, i, j);

                                    if (getMoves.Contains(Information.GetMyKingLocation()))
                                    {
                                        UndoMove(selectedSquare.Value, coord);

                                        switch (Coordinates.board[selectedSquare.Value.X, selectedSquare.Value.Y].piece)
                                        {
                                            case King:
                                                Information.UpdateKingLocation(selectedSquare.Value.X, selectedSquare.Value.Y);
                                                Information.Undo_UpdateKingEverMoved();
                                                break;
                                        }

                                        return success;
                                    }
                                }
                            }
                        }
                    }

                    switch (Coordinates.board[coord.X, coord.Y].piece)
                    {
                        case King:
                            //if the castling has been done
                            if (Math.Abs(selectedSquare.Value.X - coord.X) == 2)
                            {
                                if (coord.X == 2)
                                {
                                    //left side
                                    ForceMove(new Point(0, selectedSquare.Value.Y), new Point(3, selectedSquare.Value.Y));
                                }
                                else if (coord.X == 6)
                                {
                                    //right side
                                    ForceMove(new Point(7, selectedSquare.Value.Y), new Point(5, selectedSquare.Value.Y));
                                }
                            }
                            break;

                    }


                    selectedSquare = null;

                    return success;
                }
            }
            catch (IndexOutOfRangeException) { }
            GUIView.possibleMoves.Clear();
            return false;
        }

        private void UndoMove(Point origin, Point destination)
        {
            //origin piece should be same as destination piece
            //destination piece should be same as saved origin piece

            Coordinates.board[origin.X, origin.Y].piece = Coordinates.board[destination.X, destination.Y].piece;
            Coordinates.board[destination.X, destination.Y].piece = saved_Piece;
            Update(origin);
            Update(destination);
            Information.currentPlayer = Information.currentPlayer == Team.White ? Team.Black : Team.White;
        }


        private Piece saved_Piece;

        private void ForceMove(Point origin, Point destination)
        {
            Piece mover = Coordinates.board[origin.X, origin.Y].piece;
            Coordinates.board[destination.X, destination.Y].piece = mover;
            Coordinates.board[origin.X, origin.Y].piece = null;
            Update(origin);
            Update(destination);
        }


        private bool Move(Point origin, Point destination)
        {
            Piece mover = Coordinates.board[origin.X, origin.Y].piece;
            if (GUIView.possibleMoves.Count > 0)
            {
                saved_Piece = Coordinates.board[destination.X, destination.Y].piece;
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
