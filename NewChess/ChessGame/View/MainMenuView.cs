using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessGame.Model;

namespace ChessGame.View;

public partial class MainMenuView : Form
{
    public MainMenuView()
    {
        InitializeComponent();
    }

    private void Button_StartWhiteVsComputerGame_Click(object sender, EventArgs e)
    {
        var page = new GuiView(new GameSettings { PlayAgainstAi = true });
        ShowNewForm(page);
    }

    private void Button_StartBlackVsComputerGame_Click(object sender, EventArgs e)
    {
        var page = new GuiView(new GameSettings { PlayAgainstAi = true, CurrentTeam = Team.Black });
        ShowNewForm(page);
    }

    private void Button_StartHumanGame_Click(object sender, EventArgs e)
    {
        var page = new GuiView(new GameSettings());
        ShowNewForm(page);
    }

    private void ShowNewForm(Control page)
    {
        // Show new page
        page!.Show();

        // Hide current page
        Hide();
    }
}