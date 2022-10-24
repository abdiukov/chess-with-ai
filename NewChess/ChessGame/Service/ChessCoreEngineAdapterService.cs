using ChessEngine.Engine;

namespace ChessGame.Service;
#nullable enable
public class ChessCoreEngineAdapterService : IEngineAdapterService
{
    private readonly Engine _engine;

    public ChessCoreEngineAdapterService()
    {
        _engine = new Engine();
    }

    public string? MakeMove(byte sourceColumn, byte sourceRow, byte destinationColumn, byte destinationRow)
    {
        while (true)
        {
            if (!_engine.IsValidMove(sourceColumn, sourceRow, destinationColumn, destinationRow))
                return null;

            _engine.MovePiece(sourceColumn, sourceRow, destinationColumn, destinationRow);
            var output = MakeEngineMove();

            if (_engine.StaleMate)
            {
                if (_engine.InsufficientMaterial)
                    output += "Draw by insufficient material!";

                else if (_engine.RepeatedMove)
                    output += "Draw by repetition!";

                else if (_engine.FiftyMove)
                    output += "Draw by fifty move rule";

                else
                    output += "Stalemate!";
            }
            else if (_engine.GetWhiteMate())
                output += "Black player has successfully checkmated white!";

            else if (_engine.GetBlackMate())
                output += "White player has successfully checkmated black!";

            return output;
        }
    }

    public string MakeEngineMove()
    {
        _engine.AiPonderMove();
        var lastMove = _engine.GetMoveHistory().ToArray()[0];

        var sourceColumn = (byte)(lastMove.MovingPiecePrimary.SrcPosition % 8);
        var sourceRow = (byte)(lastMove.MovingPiecePrimary.SrcPosition / 8);
        var destinationColumn = (byte)(lastMove.MovingPiecePrimary.DstPosition % 8);
        var destinationRow = (byte)(lastMove.MovingPiecePrimary.DstPosition / 8);

        return $"{sourceColumn}{sourceRow}{destinationColumn}{destinationRow}";
    }

    public void StartGame(ChessPieceColor humanPlayer = ChessPieceColor.White,
        Engine.Difficulty gameDifficulty = Engine.Difficulty.Easy)
    {
        _engine.GameDifficulty = gameDifficulty;
        _engine.HumanPlayer = humanPlayer;
        _engine.NewGame();
    }
}