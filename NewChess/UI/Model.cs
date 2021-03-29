using ChessBoardAssets;
using ChessCore;
using GameInformation;
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
        private readonly Controller contr = new();
        public Model(ICommandHandler<ViewCommand> commandHandler)
        {
            Information.CurrentTeam = Team.White;
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

                if (piece != null && piece.Team == Information.CurrentTeam)
                {
                    selectedSquare = coord;
                    GUIView.possibleMoves = contr.GetPossibleMoves(piece, coord.X, coord.Y);
                    return true;
                }
                else if (GUIView.possibleMoves.Contains(coord))
                {
                    bool movingPieceIsKing = false;
                    Point kingLocation;
                    bool success = Move(selectedSquare.Value, coord);

                    GUIView.possibleMoves.Clear();

                    //if the moving piece is King
                    if (Coordinates.board[coord.X, coord.Y].piece is King)
                    {
                        movingPieceIsKing = true;
                        kingLocation = new(coord.X, coord.Y);
                    }
                    else
                    {
                        kingLocation = Information.GetMyKingLocation();
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
                                if (tocheck.Team == Information.CurrentTeam)
                                {
                                    List<Point?> getMoves = contr.GetPossibleMoves(tocheck, i, j);

                                    if (getMoves.Contains(kingLocation))
                                    {
                                        UndoMove(selectedSquare.Value, coord);
                                        Information.CurrentTeam = Information.CurrentTeam == Team.White ? Team.Black : Team.White;
                                        return success;
                                    }
                                    //if we moved king and it contains old king's location
                                    else if (movingPieceIsKing && getMoves.Contains(Information.GetMyKingLocation()))
                                    {
                                        if (Math.Abs(selectedSquare.Value.X - coord.X) == 2)
                                        {
                                            UndoMove(selectedSquare.Value, coord);
                                            Information.CurrentTeam = Information.CurrentTeam == Team.White ? Team.Black : Team.White;
                                            return success;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (Coordinates.board[coord.X, coord.Y].piece is Pawn)
                    {
                        if (coord.Y == 0 || coord.Y == 7)
                        {
                            //PawnUpgrade pageobj = new();
                            //pageobj.Show();

                            UpgradePawn(coord.X, coord.Y);
                        }
                    }

                    if (movingPieceIsKing)
                    {
                        //once we have moved, update the position of the king
                        Information.UpdateKingLocation(coord.X, coord.Y);
                        Information.UpdateKingEverMoved();

                        //also if castling has been done, move the rook
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
                    }

                    //logic if it is an ai

                    if (Information.PlayAgainstAI == true)
                    {
                        //mover coord.x coord.y
                        //moving plac e- selectedSquare x, selected square y
                        DoAIMove(selectedSquare.Value.X, selectedSquare.Value.Y, coord.X, coord.Y);
                    }


                    selectedSquare = null;

                    return success;
                }
            }
            catch (IndexOutOfRangeException) { }
            GUIView.possibleMoves.Clear();
            return false;
        }


        private void DoAIMove(int moverX, int moverY, int destinationX, int destinationY)
        {
            string outputFromAI = Adapter.MakeMove((byte)moverX, (byte)moverY, (byte)destinationX, (byte)destinationY);

            if (outputFromAI != "")
            {
                int x1 = int.Parse(outputFromAI[0].ToString());
                int y1 = int.Parse(outputFromAI[1].ToString());
                int x2 = int.Parse(outputFromAI[2].ToString());
                int y2 = int.Parse(outputFromAI[3].ToString());

                Point origin = new Point(x1, y1);
                Point destination = new Point(x2, y2);

                ForceMove(origin, destination);
                Information.CurrentTeam = Information.CurrentTeam == Team.White ? Team.Black : Team.White;

            }
        }

        private void UndoMove(Point origin, Point destination)
        {
            //origin piece should be same as destination piece
            //destination piece should be same as saved origin piece

            Coordinates.board[origin.X, origin.Y].piece = Coordinates.board[destination.X, destination.Y].piece;
            Coordinates.board[destination.X, destination.Y].piece = saved_Piece;
            Update(origin);
            Update(destination);
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

        public void UpgradePawn(int x, int y)
        {
            Team toUpdate = Information.CurrentTeam == Team.White ? Team.Black : Team.White;

            Piece upgradedPiece = new Queen(toUpdate);

            Coordinates.board[x, y].piece = upgradedPiece;

            Update(new Point(x, y));
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
                Information.CurrentTeam = Information.CurrentTeam == Team.White ? Team.Black : Team.White;
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
