using System;
using System.Windows.Forms;
using ChessGame.Service;
using ChessGame.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChessGame;

public static class Program
{
    public static GuiView GameWindow { get; set; }
    public static IHost ApplicationHost { get; set; }

    [STAThread]
    private static void Main()
    {
        // Set up application style
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Set up dependency injection
        ApplicationHost =
         Host.CreateDefaultBuilder()
             .ConfigureServices(services =>
             {
                 // Services
                 services.AddSingleton<IController, Controller>();
                 services.AddSingleton<IGameSettings, GameSettings>();
                 services.AddSingleton<IMovementService, MovementService>();
                 services.AddSingleton<IEngineAdapterService, ChessCoreEngineAdapterService>();

                 // Views
                 services.AddSingleton<MainMenuView>();
             }).Build();

        // Start the application
        var mainWindow = ApplicationHost.Services.GetService<MainMenuView>();
        Application.Run(mainWindow);
    }
}