using ChessCore;
using GameBoard;
using GameInformation;
using GameMovement;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{

    public class Model : ICommandHandler<ModelCommand>
    {
        private const int BoardRows = 8;
        private const int BoardColumns = 8;
        private readonly ICommandHandler<ViewCommand> commandHandler;
        private Point? selectedSquare;
        private readonly Movement contr = new();

        public Model(ICommandHandler<ViewCommand> commandHandler)
        {
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

        //CODE TO START GAME UNDER DIFFERENT CONDITIONS

        public void FirstWhiteMoveAI()
        {
            string outputFromAI = Adapter.StartAsBlack();
            ProcessAIOutput(outputFromAI);
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
            for (int i = 0; i < BoardRows; i++)
            {
                for (int j = 0; j < BoardColumns; j++)
                {
                    Update(new Point(i, j));
                }
            }
        }
        private void InitPawns(int row, Team team)
        {
            for (int i = 0; i < 8; i++)
            {
                Place(row, i, new Pawn(team));
            }
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
                    GUIView.possibleMoves.Clear();
                    ProcessMouseClickMove(coord);
                    selectedSquare = null;
                    return true;
                }
            }
            catch (IndexOutOfRangeException) { }
            GUIView.possibleMoves.Clear();
            return false;
        }


        public void ProcessMouseClickMove(Point coord)
        {
            bool movingPieceIsKing = false;
            bool kingIsCastling = false;
            Point kingLocation;
            Move(selectedSquare.Value, coord);

            //if the moving piece is King
            if (Coordinates.board[coord.X, coord.Y].piece is King)
            {
                movingPieceIsKing = true;
                kingLocation = new(coord.X, coord.Y);

                //if the king is castling
                if (Math.Abs(selectedSquare.Value.X - coord.X) == 2)
                {
                    kingIsCastling = true;
                }
            }
            else
            {
                kingLocation = Information.GetMyKingLocation();
            }


            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    Piece toCheck = Coordinates.board[i, j].piece;
                    if (toCheck != null)
                    {
                        //checking whether the opposing team can take my king
                        if (toCheck.Team != Information.CurrentTeam)
                        {
                            List<Point?> getMoves = contr.GetPossibleMoves(toCheck, i, j);

                            if (getMoves.Contains(kingLocation))
                            {
                                UndoMove(selectedSquare.Value, coord);
                                return;
                            }

                            //if we are under check and attempt to castle
                            else if (movingPieceIsKing && kingIsCastling)
                            {
                                if (getMoves.Contains(Information.GetMyKingLocation()))
                                {
                                    UndoMove(selectedSquare.Value, coord);
                                    return;
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
                    UpgradePawn(coord.X, coord.Y);
                }
            }

            if (movingPieceIsKing)
            {
                //once we have moved, update the position of the king
                Information.UpdateKingLocation(coord.X, coord.Y);
                Information.UpdateKingEverMoved();

                //also if castling has been done, move the rook
                if (kingIsCastling)
                {
                    if (coord.X == 2)
                    {
                        //left side
                        Move(new Point(0, selectedSquare.Value.Y), new Point(3, selectedSquare.Value.Y));
                    }
                    else if (coord.X == 6)
                    {
                        //right side
                        Move(new Point(7, selectedSquare.Value.Y), new Point(5, selectedSquare.Value.Y));
                    }
                }
            }

            Information.CurrentTeam = Information.CurrentTeam == Team.White ? Team.Black : Team.White;
            //logic if it is an ai
            if (Information.PlayAgainstAI)
            {
                DoAIMove(selectedSquare.Value.X, selectedSquare.Value.Y, coord.X, coord.Y);
            }
        }


        private void DoAIMove(int moverX, int moverY, int destinationX, int destinationY)
        {
            string outputFromAI = Adapter.MakeMove((byte)moverX, (byte)moverY, (byte)destinationX, (byte)destinationY);

            if (outputFromAI.Length == 4)
            {
                ProcessAIOutput(outputFromAI);
                Information.CurrentTeam = Information.CurrentTeam == Team.White ? Team.Black : Team.White;
            }
            else if (outputFromAI.Length > 4)
            {
                ProcessAIOutput(outputFromAI.Substring(0, 4));
                MessageBox.Show(outputFromAI.Substring(4), "Game over!");
                Information.CurrentTeam = Information.CurrentTeam == Team.White ? Team.Black : Team.White;
            }
            else
            {
                MessageBox.Show("Move is invalid. Please try again.");
            }

        }


        private void ProcessAIOutput(string outputFromAI)
        {
            int x1 = int.Parse(outputFromAI[0].ToString());
            int y1 = int.Parse(outputFromAI[1].ToString());
            int x2 = int.Parse(outputFromAI[2].ToString());
            int y2 = int.Parse(outputFromAI[3].ToString());

            Point origin = new Point(x1, y1);
            Point destination = new Point(x2, y2);

            Move(origin, destination);

            if (Math.Abs(x1 - x2) == 2 && Coordinates.board[x2, y2].piece is King)
            {
                if (x2 == 2)
                {
                    //left side
                    Move(new Point(0, y2), new Point(3, y2));
                }
                else if (x2 == 6)
                {
                    //right side
                    Move(new Point(7, y2), new Point(5, y2));
                }

            }
        }

        private Piece savedPiece;

        private void Move(Point origin, Point destination)
        {
            savedPiece = Coordinates.board[destination.X, destination.Y].piece;

            Piece mover = Coordinates.board[origin.X, origin.Y].piece;
            Coordinates.board[destination.X, destination.Y].piece = mover;
            Coordinates.board[origin.X, origin.Y].piece = null;
            Update(origin);
            Update(destination);
        }

        private void UndoMove(Point origin, Point destination)
        {
            //origin piece should be same as destination piece
            //destination piece should be same as saved origin piece

            Coordinates.board[origin.X, origin.Y].piece = Coordinates.board[destination.X, destination.Y].piece;
            Coordinates.board[destination.X, destination.Y].piece = savedPiece;
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

        //CODE TO UPDATE THE BOARD

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
