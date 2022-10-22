using ChessEngine.Engine;

namespace ChessGame.Service;
#nullable enable
public interface IEngineAdapterService
{
    string? MakeMove(byte sourceColumn, byte sourceRow, byte destinationColumn, byte destinationRow);
    string MakeEngineMove();
    void StartGame(ChessPieceColor humanPlayer, Engine.Difficulty gameDifficulty);
}