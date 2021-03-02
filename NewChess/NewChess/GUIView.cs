using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public partial class GUIView : Form, IView
    {
        private const int bufferDimension = 1024;
        private const int squareDimension = bufferDimension / 8;
        private Model model;
        private Bitmap buffer;
        private Point? selectedSquare;
        private Brush c1 = Brushes.BlanchedAlmond, c2 = Brushes.Silver;

        public GUIView()
        {
            InitializeComponent();


            //Initial Winodw - black vs white

            //Menu - start a new game, save the game, customise the game ( change pieces ), change color scheme

            //Rules - Castling, pawn taking, upgrade pawn, win condition, no check /checkmate / status label

            //Add a timer / 10 min game, 5 min game

            //label bottom left - that shows the status - e.g how they have it in browser

            //Graphics = is responsible for graphics ??
            InitGraphics();

            //InitModel() is responsible for Chess models
            InitModel();

            //MouseClicck = is saying that if a mouse is clicked, go to the GUIView_MouseClick method
            this.MouseClick += GUIView_MouseClick;
        }

        public new void Handle(ViewCommand command) { command.execute(this); }

        private void GUIView_MouseClick(object sender, MouseEventArgs e)
        {
            // get the width of the form and divide by 8
            // get the height of gui form and divide by 8
            Point? coord = new Point(e.X / (this.ClientSize.Width / 8), e.Y / (this.ClientSize.Height / 8));

            //SelectSquareCommand selectCommand = new SelectSquareCommand(coord.Value);

            //creates the command and says to model - go handle that command bro

            //model.Handle(selectCommand);

            //if its succcessful, create selected square
            //selectedSquare = (selectCommand.Success ? coord : null);

            // redirects to GUIView_Paint
            this.Invalidate();
        }

        private void InitModel()
        {
            model = new Model(this);
            model.Handle(new StartGameCommand());
        }

        private void InitGraphics()
        {
            buffer = new Bitmap(bufferDimension, bufferDimension);
            this.DoubleBuffered = true;
            // that is why Paint by default is GuiView paint
            this.Paint += GUIView_Paint;
            this.Resize += GUIView_Resize;
        }

        void GUIView_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
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
                e.Graphics.DrawRectangle(new Pen(Color.Green, lineSize), highlight.X * x, highlight.Y * y, x, y);
            }
        }

        public void DrawSquare(Image background, Image piece, Point coord)
        {
            Brush brush = (coord.Y % 2 == 0) ? (coord.X % 2 == 0) ? c1 : c2 : (coord.X % 2 == 0) ? c2 : c1;
            using (Graphics g = Graphics.FromImage(buffer))
            {
                g.FillRectangle(brush, coord.X * squareDimension, coord.Y * squareDimension, squareDimension, squareDimension);
                g.DrawImage(background, coord.X * squareDimension, coord.Y * squareDimension, squareDimension, squareDimension);
                if (piece != null)
                {
                    g.DrawImage(piece, coord.X * squareDimension, coord.Y * squareDimension, squareDimension, squareDimension);
                }
            }
        }
    }
}
