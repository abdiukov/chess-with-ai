namespace ChessGameTests;

using NUnit.Framework;
using ChessGame;
using ChessGame.Model;
using System.Drawing;

[TestFixture]
public class GameSettingsTests
{
    private GameSettings _settings;

    [SetUp]
    public void Setup()
    {
        _settings = new GameSettings();
    }

    [Test]
    public void Test_Initial_State() // Testing initial state
    {
        Assert.IsFalse(_settings.PlayAgainstAi);
        Assert.That(_settings.CurrentTeam, Is.EqualTo(Team.White));
        Assert.That(_settings.WhiteKingLocation, Is.EqualTo(new Point(4, 7)));
        Assert.That(_settings.BlackKingLocation, Is.EqualTo(new Point(4, 0)));
    }

    [Test]
    public void Test_GetMyKingLocation_WhiteTeam() // Testing GetMyKingLocation for white team
    {
        _settings.CurrentTeam = Team.White;
        Assert.That(_settings.GetMyKingLocation(), Is.EqualTo(_settings.WhiteKingLocation));
    }

    [Test]
    public void Test_GetMyKingLocation_BlackTeam() // Testing GetMyKingLocation for black team
    {
        _settings.CurrentTeam = Team.Black;
        Assert.That(_settings.GetMyKingLocation(), Is.EqualTo(_settings.BlackKingLocation));
    }

    [Test]
    public void Test_UpdateKingLocation() // Testing UpdateKingLocation method
    {
        _settings.CurrentTeam = Team.White;
        _settings.UpdateKingLocation(5, 6);
        Assert.That(_settings.GetMyKingLocation(), Is.EqualTo(new Point(5, 6)));

        _settings.CurrentTeam = Team.Black;
        _settings.UpdateKingLocation(7, 8);
        Assert.That(_settings.GetMyKingLocation(), Is.EqualTo(new Point(7, 8)));
    }

    [Test]
    public void Test_PlayAgainstAi_Update()
    {
        // Act
        _settings.PlayAgainstAi = true;

        // Assert
        Assert.IsTrue(_settings.PlayAgainstAi);
    }

    [Test]
    public void Test_CurrentTeam_Update()
    {
        // Act
        _settings.CurrentTeam = Team.Black;

        // Assert
        Assert.That(_settings.CurrentTeam, Is.EqualTo(Team.Black));
    }

    [Test]
    public void Test_WhiteKingLocation_Update()
    {
        // Arrange
        var newLocation = new Point(6, 7);

        // Act
        _settings.WhiteKingLocation = newLocation;

        // Assert
        Assert.That(_settings.WhiteKingLocation, Is.EqualTo(newLocation));
    }

    [Test]
    public void Test_BlackKingLocation_Update()
    {
        // Arrange
        var newLocation = new Point(6, 0);

        // Act
        _settings.BlackKingLocation = newLocation;

        // Assert
        Assert.That(_settings.BlackKingLocation, Is.EqualTo(newLocation));
    }

    [Test]
    public void Test_UpdateWhiteKingLocation()
    {
        // Arrange
        _settings.CurrentTeam = Team.White;
        var newLocation = new Point(5, 5);

        // Act
        _settings.UpdateKingLocation(newLocation.X, newLocation.Y);

        // Assert
        Assert.That(_settings.WhiteKingLocation, Is.EqualTo(newLocation));
    }

    [Test]
    public void Test_UpdateBlackKingLocation()
    {
        // Arrange
        _settings.CurrentTeam = Team.Black;
        var newLocation = new Point(4, 4);

        // Act
        _settings.UpdateKingLocation(newLocation.X, newLocation.Y);

        // Assert
        Assert.That(_settings.BlackKingLocation, Is.EqualTo(newLocation));
    }
}