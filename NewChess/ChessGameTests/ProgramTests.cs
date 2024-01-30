using ChessGame;
using ChessGame.Service;
using ChessGame.View;
using Microsoft.Extensions.DependencyInjection;

namespace ChessGameTests;

[TestFixture]
public class ProgramTests
{
    private IServiceProvider _serviceProvider;

    [OneTimeSetUp]
    public void Setup()
    {
        Task.Run(() => ChessGame.Program.Main());
        Thread.Sleep(3000);
        _serviceProvider = ChessGame.Program.ApplicationHost.Services;
    }

    [Test]
    public void TestDependencyInjectionSetupForController()
    {
        var controller = _serviceProvider.GetService<IController>();
        Assert.IsNotNull(controller, "Controller Dependency not resolved");
    }

    [Test]
    public void TestDependencyInjectionSetupForGameSettings()
    {
        var gameSettings = _serviceProvider.GetService<IGameSettings>();
        Assert.IsNotNull(gameSettings, "GameSettings Dependency not resolved");
    }

    [Test]
    public void TestDependencyInjectionSetupForMovementService()
    {
        var movementService = _serviceProvider.GetService<IMovementService>();
        Assert.IsNotNull(movementService, "MovementService dependency not resolved");
    }

    [Test]
    public void TestDependencyInjectionSetupForEngineAdapterService()
    {
        var engineAdapterService = _serviceProvider.GetService<IEngineAdapterService>();
        Assert.IsNotNull(engineAdapterService, "EngineAdapterService dependency not resolved");
    }

    [Test]
    public void TestDependencyInjectionSetupForMainMenuView()
    {
        var mainMenuView = _serviceProvider.GetService<MainMenuView>();
        Assert.IsNotNull(mainMenuView, "MainMenuView dependency not resolved");
    }
}