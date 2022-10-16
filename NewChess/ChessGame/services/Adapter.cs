using System;
using ChessEngine.Engine;

namespace ChessGame.services;

public class Adapter
{
    private static readonly Engine Engine = new();

    public static string MakeMove(byte srcCol, byte srcRow,
        byte dstCol, byte dstRow)
    {
        while (true)
        {
            try
            {
                if (Engine.WhoseMove == Engine.HumanPlayer)
                {
                    if (!Engine.IsValidMove(srcCol, srcRow, dstCol, dstRow))
                    {
                        return "";
                    }

                    Engine.MovePiece(srcCol, srcRow, dstCol, dstRow);

                    var output = MakeEngineMove(Engine);

                    if (Engine.StaleMate)
                    {
                        if (Engine.InsufficientMaterial)
                        {
                            output += "Draw by insufficient material!";
                        }
                        else if (Engine.RepeatedMove)
                        {
                            output += "Draw by repetition!";
                        }
                        else if (Engine.FiftyMove)
                        {
                            output += "Draw by fifty move rule";
                        }
                        else
                        {
                            output += "Stalemate!";
                        }
                    }
                    else if (Engine.GetWhiteMate())
                    {
                        output += "Black player has successfully checkmated white!";
                    }
                    else if (Engine.GetBlackMate())
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

        var lastMove = engine.GetMoveHistory().ToArray()[0];

        var sourceColumn = (byte)(lastMove.MovingPiecePrimary.SrcPosition % 8);
        var srcRow = (byte)(lastMove.MovingPiecePrimary.SrcPosition / 8);
        var destinationColumn = (byte)(lastMove.MovingPiecePrimary.DstPosition % 8);
        var destinationRow = (byte)(lastMove.MovingPiecePrimary.DstPosition / 8);

        var output = sourceColumn + srcRow.ToString() + destinationColumn + destinationRow;

        return output;
    }
    public static void StartGame()
    {
        Engine.NewGame();
        Engine.GameDifficulty = Engine.Difficulty.Easy;
    }

    public static string StartAsBlack()
    {
        Engine.HumanPlayer = ChessPieceColor.Black;
        return MakeEngineMove(Engine);
    }

}