using System;
using ChessGame.Model;
using ChessGame.View;

namespace ChessGame;

public partial class MainMenu : ChessGameForm
{
    public MainMenu() => InitializeComponent();

    private async void Button_StartWhiteVsComputerGame_Click(object sender, EventArgs e)
    {
        var page = new GuiView(new GameSettings { PlayAgainstAi = true });
        await ShowNewForm(page);
    }

    private async void Button_StartBlackVsComputerGame_Click(object sender, EventArgs e)
    {
        var page = new GuiView(new GameSettings { PlayAgainstAi = true, CurrentTeam = Team.Black });
        await ShowNewForm(page);
    }

    private async void Button_StartHumanGame_Click(object sender, EventArgs e)
    {
        var page = new GuiView(new GameSettings());
        await ShowNewForm(page);
    }
}