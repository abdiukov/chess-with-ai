using Chess;
using ChessCore;
using GameInformation;
using System.Windows.Forms;

namespace UI
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }


        private void StartGame()
        {
            Information.SetDefaultValues();
            GUIView pageobj = new();
            pageobj.Show();
            this.Hide();
        }

        private void StartGameBlackVSAI()
        {
            Information.SetDefaultValues();
            GUIView pageobj = new();
            pageobj.Show();
            this.Hide();
            pageobj.StartAsBlackAgainstAI();
        }

        private void button_StartWhiteVsComputerGame_Click(object sender, System.EventArgs e)
        {
            Adapter.StartGame();
            Information.PlayAgainstAI = true;
            StartGame();
        }

        private void button_StartBlackVsComputerGame_Click(object sender, System.EventArgs e)
        {
            Adapter.StartGame();
            Information.PlayAgainstAI = true;
            StartGameBlackVSAI();
        }

        private void button_StartHumanGame_Click(object sender, System.EventArgs e)
        {
            Adapter.StartGame();
            Information.PlayAgainstAI = false;
            StartGame();
        }
    }
}
