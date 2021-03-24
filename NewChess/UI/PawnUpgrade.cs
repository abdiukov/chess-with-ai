using GameInfo;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace UI
{
    public partial class PawnUpgrade : Form
    {
        ManualResetEvent mrse = new(false);

        private string userChoice;

        public PawnUpgrade()
        {
            InitializeComponent();


            if (Information.currentPlayer == Team.White)
            {
                //get the black
                pictureBox_Bishop.Image = Image.FromFile("Bishop_B.png");
                pictureBox_Queen.Image = Image.FromFile("Queen_B.png");
                pictureBox_Knight.Image = Image.FromFile("Knight_B.png");
                pictureBox_Rook.Image = Image.FromFile("Rook_B.png");
            }
            else
            {
                //get the white
                pictureBox_Bishop.Image = Image.FromFile("Bishop_W.png");
                pictureBox_Queen.Image = Image.FromFile("Queen_W.png");
                pictureBox_Knight.Image = Image.FromFile("Knight_W.png");
                pictureBox_Rook.Image = Image.FromFile("Rook_W.png");
            }

        }
        public string GetUserNewPieceChoice()
        {
            this.Show();

            Sleep();

            this.Close();
            return userChoice;
        }

        private void pictureBox_Queen_Click(object sender, EventArgs e)
        {
            userChoice = "Queen";

            mrse.Set();
        }

        private void pictureBox_Rook_Click(object sender, EventArgs e)
        {
            userChoice = "Rook";

            mrse.Set();


        }

        private void pictureBox_Bishop_Click(object sender, EventArgs e)
        {
            userChoice = "Bishop";

            mrse.Set();

        }

        private void pictureBox_Knight_Click(object sender, EventArgs e)
        {
            userChoice = "Knight";

            mrse.Set();

        }

        private void Sleep()
        {
            mrse.WaitOne();
        }
    }
}