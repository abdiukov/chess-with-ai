using View;
using ChessCoreEngineAdapter;
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
            Information.PlayAgainstAI = true;
            Information.SetDefaultValues();
            GUIView pageobj = new();
            pageobj.Show();
            this.Hide();
            pageobj.StartAsBlackAgainstAI();
        }

        private void Button_StartWhiteVsComputerGame_Click(object sender, System.EventArgs e)
        {
            Adapter.StartGame();
            Information.PlayAgainstAI = true;
            StartGame();
        }

        private void Button_StartBlackVsComputerGame_Click(object sender, System.EventArgs e)
        {
            Adapter.StartGame();
            StartGameBlackVSAI();
        }

        private void Button_StartHumanGame_Click(object sender, System.EventArgs e)
        {
            Adapter.StartGame();
            Information.PlayAgainstAI = false;
            StartGame();
        }
    }
}
