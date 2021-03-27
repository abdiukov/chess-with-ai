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
            engine.AiPonderMove();

            MoveContent lastMove = engine.GetMoveHistory().ToArray()[0];

            string output;

            var sourceColumn = (byte)(lastMove.MovingPiecePrimary.SrcPosition % 8);
            var srcRow = (byte)(8 - (lastMove.MovingPiecePrimary.SrcPosition / 8));
            var destinationColumn = (byte)(lastMove.MovingPiecePrimary.DstPosition % 8);
            var destinationRow = (byte)(8 - (lastMove.MovingPiecePrimary.DstPosition / 8));

            ConvertToMyCustomRows(ref srcRow);
            ConvertToMyCustomRows(ref destinationRow);


            output = sourceColumn + "-" + srcRow + " " + destinationColumn + "-" + destinationRow;

            return output;
        }


        //converting the Row so it is compatible with my program
        //or in other words, converting the y value
        private static void ConvertToMyCustomRows(ref byte RowToConvert)
        {
            switch (RowToConvert)
            {
                case 1:
                    RowToConvert = 7;
                    break;
                case 2:
                    RowToConvert = 6;
                    break;
                case 3:
                    RowToConvert = 5;
                    break;
                case 4:
                    RowToConvert = 4;
                    break;
                case 5:
                    RowToConvert = 3;
                    break;
                case 6:
                    RowToConvert = 2;
                    break;
                case 7:
                    RowToConvert = 1;
                    break;
                case 8:
                    RowToConvert = 0;
                    break;
            }
        }

    }
}
