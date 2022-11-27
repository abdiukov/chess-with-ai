using System;
using System.Windows.Forms;
using ChessGame.Service;
using ChessGame.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChessGame;

internal static class Program
{
    public static MainMenuView MainMenuView = new();
    public static GuiView GameWindow;
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Set up dependency injection
        var host = Host
         .CreateDefaultBuilder()
         .ConfigureServices(service =>
         {
             // Services
             service.AddSingleton<IController, Controller>();
             service.AddSingleton<IGameSettings, GameSettings>();
             service.AddSingleton<IMovementService, MovementService>();
             service.AddSingleton<IEngineAdapterService, ChessCoreEngineAdapterService>();

             // Views
             service.AddTransient<IGameView, GuiView>();
             service.AddTransient<IMainMenuView, MainMenuView>();

         }).Build();

        // Start the application
        Application.Run(MainMenuView);
    }
}