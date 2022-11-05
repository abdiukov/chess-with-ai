using System;
using System.Windows.Forms;
using ChessGame.View;

namespace ChessGame;

internal static class Program
{
    public static MainMenu MainMenu = new();
    public static GuiView GameWindow;
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(MainMenu);
    }
}