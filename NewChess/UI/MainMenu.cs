using Chess;
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

        private void button_PlayAsWhite_Click(object sender, System.EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            GUIView pageobj = new();
            pageobj.Show();
            this.Hide();
        }
    }
}
