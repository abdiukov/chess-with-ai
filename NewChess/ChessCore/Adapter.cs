using ChessEngine.Engine;
using System;

namespace ChessCore
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

                        return MakeEngineMove(engine);
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




    }
}
