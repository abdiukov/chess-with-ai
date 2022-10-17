using System;
using System.Windows.Forms;

namespace ChessGame;

public partial class MainMenu : Form
{
    public MainMenu() => InitializeComponent();

    private void Button_StartWhiteVsComputerGame_Click(object sender, EventArgs e)
    {
        GuiView page = new();
        page.Show();
        Hide();
        page.StartAsWhiteAgainstAi();
    }

    private void Button_StartBlackVsComputerGame_Click(object sender, EventArgs e)
    {
        GuiView page = new();
        page.Show();
        Hide();
        page.StartAsBlackAgainstAi();
    }

    private void Button_StartHumanGame_Click(object sender, EventArgs e)
    {
        GuiView page = new();
        page.Show();
        Hide();
        page.StartAsWhiteAgainstPlayer();
    }
}