using System;
using System.Windows.Forms;

namespace ChessGame;

public partial class MainMenu : Form
{
    public MainMenu() => InitializeComponent();

    private void Button_StartWhiteVsComputerGame_Click(object sender, EventArgs e)
    {
        var page = new GuiView();
        page.Controller.StartAsWhiteAgainstAi();
        page.Show();

        Hide();
    }

    private void Button_StartBlackVsComputerGame_Click(object sender, EventArgs e)
    {
        var page = new GuiView();
        page.Controller.StartAsBlackAgainstAi();
        page.Show();

        Hide();
    }

    private void Button_StartHumanGame_Click(object sender, EventArgs e)
    {
        var page = new GuiView();
        page.Controller.StartAsWhiteAgainstPlayer();
        page.Show();

        Hide();
    }
}