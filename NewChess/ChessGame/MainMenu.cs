using System;
using System.Windows.Forms;
using ChessGame.Data;
using ChessGame.Model;

namespace ChessGame;

public partial class MainMenu : Form
{
    public MainMenu() => InitializeComponent();

    private void Button_StartWhiteVsComputerGame_Click(object sender, EventArgs e)
    {
        var information = new Information { PlayAgainstAi = true };
        var page = new GuiView(information);
        page.Show();

        Hide();
    }

    private void Button_StartBlackVsComputerGame_Click(object sender, EventArgs e)
    {
        var information = new Information { PlayAgainstAi = true, CurrentTeam = Team.Black };

        var page = new GuiView(information);
        page.Show();

        Hide();
    }

    private void Button_StartHumanGame_Click(object sender, EventArgs e)
    {
        var information = new Information();

        var page = new GuiView(information);
        page.Show();

        Hide();
    }
}