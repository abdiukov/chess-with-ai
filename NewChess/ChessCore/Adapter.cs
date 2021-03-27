using ChessEngine.Engine;
using System;

namespace ChessCore
{
    class Adapter
    {
        public static Engine engine = new Engine();

        private static void MakeMove(byte srcCol, byte srcRow,
        byte dstCol, byte dstRow)
        {
            while (true)
            {
                try
                {
                    if (engine.WhoseMove != engine.HumanPlayer)
                    {
                        MakeEngineMove(engine);
                    }
                    else
                    {

                        if (!engine.IsValidMove(srcCol, srcRow, dstCol, dstRow))
                        {
                            Console.WriteLine("Invalid Move");
                            continue;
                        }

                        engine.MovePiece(srcCol, srcRow, dstCol, dstRow);

                        MakeEngineMove(engine);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //exit the while loop
                return;

            }
        }

        private static string MakeEngineMove(Engine engine)
        {
            DateTime start = DateTime.Now;

            engine.AiPonderMove();

            MoveContent lastMove = engine.GetMoveHistory().ToArray()[0];

            string tmp = "";

            var sourceColumn = (byte)(lastMove.MovingPiecePrimary.SrcPosition % 8);
            var srcRow = (byte)(8 - (lastMove.MovingPiecePrimary.SrcPosition / 8));
            var destinationColumn = (byte)(lastMove.MovingPiecePrimary.DstPosition % 8);
            var destinationRow = (byte)(8 - (lastMove.MovingPiecePrimary.DstPosition / 8));

            tmp += GetPgnMove(lastMove.MovingPiecePrimary.PieceType);

            if (lastMove.MovingPiecePrimary.PieceType == ChessPieceType.Knight)
            {
                tmp += GetColumnFromInt(sourceColumn + 1);
                tmp += srcRow;
            }
            else if (lastMove.MovingPiecePrimary.PieceType == ChessPieceType.Rook)
            {
                tmp += GetColumnFromInt(sourceColumn + 1);
                tmp += srcRow;
            }
            else if (lastMove.MovingPiecePrimary.PieceType == ChessPieceType.Pawn)
            {
                if (sourceColumn != destinationColumn)
                {
                    tmp += GetColumnFromInt(sourceColumn + 1);
                }
            }

            if (lastMove.TakenPiece.PieceType != ChessPieceType.None)
            {
                tmp += "x";
            }

            tmp += GetColumnFromInt(destinationColumn + 1);

            tmp += destinationRow;

            if (lastMove.PawnPromotedTo == ChessPieceType.Queen)
            {
                tmp += "=Q";
            }
            else if (lastMove.PawnPromotedTo == ChessPieceType.Rook)
            {
                tmp += "=R";
            }
            else if (lastMove.PawnPromotedTo == ChessPieceType.Knight)
            {
                tmp += "=K";
            }
            else if (lastMove.PawnPromotedTo == ChessPieceType.Bishop)
            {
                tmp += "=B";
            }

            DateTime end = DateTime.Now;

            TimeSpan ts = end - start;

            Console.Write(engine.PlyDepthReached + " ");

            int score = engine.GetScore();

            if (score > 0)
            {
                score = score / 10;
            }

            return tmp;
        }

        public static string GetColumnFromInt(int column)
        {
            string returnColumnt;

            switch (column)
            {
                case 1:
                    returnColumnt = "a";
                    break;
                case 2:
                    returnColumnt = "b";
                    break;
                case 3:
                    returnColumnt = "c";
                    break;
                case 4:
                    returnColumnt = "d";
                    break;
                case 5:
                    returnColumnt = "e";
                    break;
                case 6:
                    returnColumnt = "f";
                    break;
                case 7:
                    returnColumnt = "g";
                    break;
                case 8:
                    returnColumnt = "h";
                    break;
                default:
                    returnColumnt = "Unknown";
                    break;
            }

            return returnColumnt;
        }

        private static string GetPgnMove(ChessPieceType pieceType)
        {
            string move = "";

            if (pieceType == ChessPieceType.Bishop)
            {
                move += "B";
            }
            else if (pieceType == ChessPieceType.King)
            {
                move += "K";
            }
            else if (pieceType == ChessPieceType.Knight)
            {
                move += "N";
            }
            else if (pieceType == ChessPieceType.Queen)
            {
                move += "Q";
            }
            else if (pieceType == ChessPieceType.Rook)
            {
                move += "R";
            }

            return move;
        }

        private static byte GetRow(string move)
        {
            if (move != null)
            {
                if (move.Length == 2)
                {
                    return (byte)(8 - int.Parse(move.Substring(1, 1).ToLower()));
                }
            }

            return 255;
        }

        private static byte GetColumn(string move)
        {
            if (move != null)
            {
                if (move.Length == 2)
                {
                    string col = move.Substring(0, 1).ToLower();

                    switch (col)
                    {
                        case "a":
                            {
                                return 0;
                            }
                        case "b":
                            {
                                return 1;
                            }
                        case "c":
                            {
                                return 2;
                            }
                        case "d":
                            {
                                return 3;
                            }
                        case "e":
                            {
                                return 4;
                            }
                        case "f":
                            {
                                return 5;
                            }
                        case "g":
                            {
                                return 6;
                            }
                        case "h":
                            {
                                return 7;
                            }
                        default:
                            return 255;
                    }
                }
            }

            return 255;
        }

    }
}
