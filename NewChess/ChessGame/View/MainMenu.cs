using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessGame.Model;

namespace ChessGame.View;

public partial class MainMenu : Form
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

    private Task ShowNewForm(Form page)
    {
        // Show new page
        page!.Show();

        // Hide current page
        Hide();

        return Task.CompletedTask;
    }
}