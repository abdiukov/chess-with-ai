using System.Windows.Forms;
using View;

namespace UI
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Button_StartWhiteVsComputerGame_Click(object sender, System.EventArgs e)
        {
            GUIView pageobj = new();
            pageobj.Show();
            Hide();
            pageobj.StartAsWhiteAgainstAI();
        }

        private void Button_StartBlackVsComputerGame_Click(object sender, System.EventArgs e)
        {
            GUIView pageobj = new();
            pageobj.Show();
            Hide();
            pageobj.StartAsBlackAgainstAI();
        }

        private void Button_StartHumanGame_Click(object sender, System.EventArgs e)
        {
            GUIView pageobj = new();
            pageobj.Show();
            Hide();
            pageobj.StartAsWhiteAgainstPlayer();
        }
    }
}
