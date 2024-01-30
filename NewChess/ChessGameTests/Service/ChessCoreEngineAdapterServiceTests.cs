namespace ChessGameTests.Service;

using NUnit.Framework;
using ChessGame.Service;
using ChessEngine.Engine;

[TestFixture]
public class ChessCoreEngineAdapterServiceTests
{
    private ChessCoreEngineAdapterService _service;

    [SetUp]
    public void Initialize()
    {
        _service = new ChessCoreEngineAdapterService();
    }

    [Test]
    public void TestMakeMoveValid()
    {
        // Arrange
        byte sourceColumn = 1;
        byte sourceRow = 1;
        byte destinationColumn = 1;
        byte destinationRow = 2;

        // Act
        var result = _service.MakeMove(sourceColumn, sourceRow, destinationColumn, destinationRow);

        // Assert
        Assert.IsNotNull(result);
    }

    [Test]
    public void TestMakeMoveInvalid()
    {
        // Arrange
        byte sourceColumn = 9;
        byte sourceRow = 9;
        byte destinationColumn = 1;
        byte destinationRow = 2;

        // Act
        TestDelegate result = () => _service.MakeMove(sourceColumn, sourceRow, destinationColumn, destinationRow);

        // Assert
        Assert.Throws<IndexOutOfRangeException>(result);
    }

    [Test]
    public void TestMakeEngineMove()
    {
        // Act
        var result = _service.MakeEngineMove();

        // Assert
        Assert.IsNotNull(result);
    }

    [TestCase(ChessPieceColor.White, Engine.Difficulty.Easy)]
    [TestCase(ChessPieceColor.Black, Engine.Difficulty.Hard)]
    public void TestStartGame(ChessPieceColor humanPlayer, Engine.Difficulty gameDifficulty)
    {
        // Act
        _service.StartGame(humanPlayer, gameDifficulty);

        // Assert
        // If there is no exception thrown, then the test is successful.
        Assert.Pass();
    }

    [Test]
    public void TestMakeEngineMoveNoHistory()
    {
        // Arrange
        _service.StartGame();

        // Act & Assert
        Assert.DoesNotThrow(() => _service.MakeEngineMove());
    }

    [TestCase(ChessPieceColor.White, Engine.Difficulty.Medium)]
    [TestCase(ChessPieceColor.Black, Engine.Difficulty.Medium)]
    [TestCase(ChessPieceColor.White, Engine.Difficulty.Hard)]
    public void TestStartGameDifferentSettings(ChessPieceColor humanPlayer, Engine.Difficulty gameDifficulty)
    {
        // Act
        _service.StartGame(humanPlayer, gameDifficulty);

        // Assert
        // If there is no exception thrown, then the test is successful.
        Assert.Pass();
    }

}