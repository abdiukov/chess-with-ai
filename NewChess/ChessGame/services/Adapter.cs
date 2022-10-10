using ChessEngine.Engine;
using System;

namespace ChessCoreEngineAdapter
{
    public class Adapter
    {
        private static readonly Engine engine = new Engine();

        public static string MakeMove(byte srcCol, byte srcRow,
        byte dstCol, byte dstRow)
        {
            while (true)
            {
                try
                {
                    if (engine.WhoseMove == engine.HumanPlayer)
                    {
                        if (!engine.IsValidMove(srcCol, srcRow, dstCol, dstRow))
                        {
                            return "";
                        }

                        engine.MovePiece(srcCol, srcRow, dstCol, dstRow);

                        string output = MakeEngineMove(engine);

                        if (engine.StaleMate)
                        {
                            if (engine.InsufficientMaterial)
                            {
                                output += "Draw by insufficient material!";
                            }
                            else if (engine.RepeatedMove)
                            {
                                output += "Draw by repetition!";
                            }
                            else if (engine.FiftyMove)
                            {
                                output += "Draw by fifty move rule";
                            }
                            else
                            {
                                output += "Stalemate!";
                            }
                        }
                        else if (engine.GetWhiteMate())
                        {
                            output += "Black player has successfully checkmated white!";
                        }
                        else if (engine.GetBlackMate())
                        {
                            output += "White player has successfully checkmated black!";
                        }
                        return output;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //exit the while loop
                return "";

            }
        }

        private static string MakeEngineMove(Engine engine)
        {
            engine.AiPonderMove();

            MoveContent lastMove = engine.GetMoveHistory().ToArray()[0];

            string output;

            var sourceColumn = (byte)(lastMove.MovingPiecePrimary.SrcPosition % 8);
            var srcRow = (byte)(lastMove.MovingPiecePrimary.SrcPosition / 8);
            var destinationColumn = (byte)(lastMove.MovingPiecePrimary.DstPosition % 8);
            var destinationRow = (byte)(lastMove.MovingPiecePrimary.DstPosition / 8);

            output = sourceColumn.ToString() + srcRow.ToString() + destinationColumn.ToString() + destinationRow.ToString();

            return output;
        }
        public static void StartGame()
        {
            engine.NewGame();
            engine.GameDifficulty = Engine.Difficulty.Easy;
        }

        public static string StartAsBlack()
        {
            engine.HumanPlayer = ChessPieceColor.Black;
            return MakeEngineMove(engine);
        }

    }
}
