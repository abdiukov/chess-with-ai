using GameInformation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public partial class GUIView : Form, IView
    {
        private readonly int dimension = (int)(Screen.PrimaryScreen.Bounds.Height * 0.95);
        private const int bufferDimension = 1024;
        private const int squareDimension = bufferDimension / 8;
        private Model model;
        private Bitmap buffer;
        private Point? selectedSquare;
        private readonly Brush c1 = Brushes.BlanchedAlmond, c2 = Brushes.Silver;
        public static List<Point?> possibleMoves = new();

        public GUIView()
        {
            InitializeComponent();
            InitGraphics();
            InitModel();
            this.MouseClick += GUIView_MouseClick;
        }

        public new void Handle(ViewCommand command) { command.Execute(this); }

        private void GUIView_MouseClick(object sender, MouseEventArgs e)
        {
            Point? coord = new Point(e.X / (this.ClientSize.Width / 8), e.Y / (this.ClientSize.Height / 8));
            SelectSquareCommand selectCommand = new(coord.Value);

            //creates the command and says to model - go handle that command bro
            model.Handle(selectCommand);

            //if its succcessful, create selected square
            selectedSquare = (selectCommand.Success ? coord : null);


            this.Invalidate();
        }

        private void InitModel()
        {
            model = new Model(this);
            model.Handle(new StartGameCommand());
        }

        private void InitGraphics()
        {
            this.MaximizeBox = false;
            this.MaximumSize = new Size(dimension, dimension);
            this.MinimumSize = new Size(dimension / 2, dimension / 2);
            this.Size = new Size(dimension, dimension);
            buffer = new Bitmap(bufferDimension, bufferDimension);
            this.DoubleBuffered = true;
            this.Paint += GUIView_Paint;
            this.Resize += GUIView_Resize;
        }

        void GUIView_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.Height = this.Width;
                this.Invalidate();
            }

        }

        private void GUIView_Paint(object sender, PaintEventArgs e)
        {
            int x = this.ClientSize.Width / 8;
            int y = this.ClientSize.Height / 8;
            int lineSize = (x + y / 2) / 25;
            e.Graphics.DrawImage(buffer, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
            if (selectedSquare != null)
            {
                Point highlight = selectedSquare.Value;
                e.Graphics.DrawRectangle(new Pen(Color.Yellow, lineSize), highlight.X * x, highlight.Y * y, x, y);
            }
            if (possibleMoves.Count > 0)
            {
                foreach (var item in possibleMoves)
                {
                    Point highlight = (Point)item;
                    e.Graphics.DrawRectangle(new Pen(Color.Green, lineSize), highlight.X * x, highlight.Y * y, x, y);
                }
            }

        }

        private void GUIView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Information.SetDefaultValues();
            Program.mainMenu.Show();
        }

        public void DrawSquare(Image piece, Point coord)
        {
            Brush brush = (coord.Y % 2 == 0) ? (coord.X % 2 == 0) ? c1 : c2 : (coord.X % 2 == 0) ? c2 : c1;
            using Graphics g = Graphics.FromImage(buffer);
            g.FillRectangle(brush, coord.X * squareDimension, coord.Y * squareDimension, squareDimension, squareDimension);
            if (piece != null)
            {
                g.DrawImage(piece, coord.X * squareDimension, coord.Y * squareDimension, squareDimension, squareDimension);
            }
        }
    }
}
