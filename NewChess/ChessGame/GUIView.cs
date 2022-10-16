using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame;

public partial class GuiView : Form, IView
{
    private readonly int _dimension = (int)(Screen.PrimaryScreen.Bounds.Height * 0.95);
    private const int BufferDimension = 1024;
    private const int SquareDimension = BufferDimension / 8;
    private Controller _controller;
    private Bitmap _buffer;
    private Point? _selectedSquare;
    private readonly Brush _c1 = Brushes.BlanchedAlmond, _c2 = Brushes.Silver;

    public List<Point?> PossibleMoves = new();

    //INITIALIZATION CODE

    public GuiView()
    {
        InitializeComponent();
        InitGraphics();
        InitModel();
        MouseClick += GUIView_MouseClick;
        Program.GameWindow = this;
    }

    private void InitModel()
    {
        _controller = new Controller(this);
        _controller.Handle(new StartGameCommand());
    }

    private void InitGraphics()
    {
        MaximizeBox = false;
        MaximumSize = new Size(_dimension, _dimension);
        MinimumSize = new Size(_dimension / 2, _dimension / 2);
        Size = new Size(_dimension, _dimension);
        _buffer = new Bitmap(BufferDimension, BufferDimension);
        DoubleBuffered = true;
        Paint += GUIView_Paint;
        Resize += GUIView_Resize;
    }

    //DIFFERENT START CONDITIONS CODE

    public void StartAsBlackAgainstAi()
    {
        _controller.PlayAsBlackAgainstAi();
    }

    public void StartAsWhiteAgainstAi()
    {
        _controller.StartAsWhiteAgainstAi();
    }

    public void StartAsWhiteAgainstPlayer()
    {
        _controller.StartAsWhiteAgainstPlayer();
    }

    //RESPOND TO USER INPUT CODE

    public new void Handle(ViewCommand command) { command.Execute(this); }

    private void GUIView_MouseClick(object sender, MouseEventArgs e)
    {
        Point? coordinate = new Point(e.X / (ClientSize.Width / 8), e.Y / (ClientSize.Height / 8));
        SelectSquareCommand selectCommand = new(coordinate.Value);

        //creates the command and says to model - go handle that command
        _controller.Handle(selectCommand);

        //if its successful, create selected square
        _selectedSquare = selectCommand.Success ? coordinate : null;

        Invalidate();
    }

    //RESIZE CODE
    private void GUIView_Resize(object sender, EventArgs e)
    {
        if (WindowState == FormWindowState.Minimized) 
            return;

        Height = Width;
        Invalidate();
    }

    //DRAW GRAPHICS CODE

    private void GUIView_Paint(object sender, PaintEventArgs e)
    {
        var x = ClientSize.Width / 8;
        var y = ClientSize.Height / 8;
        var lineSize = (x + y / 2) / 25;
        e.Graphics.DrawImage(_buffer, 0, 0, ClientSize.Width, ClientSize.Height);
        if (_selectedSquare != null)
        {
            var highlight = _selectedSquare.Value;
            e.Graphics.DrawRectangle(new Pen(Color.Yellow, lineSize), highlight.X * x, highlight.Y * y, x, y);
        }
        foreach (Point highlight in PossibleMoves)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Green, lineSize), highlight.X * x, highlight.Y * y, x, y);
        }
    }

    public void DrawSquare(Image piece, Point coordinate)
    {
        var brush = coordinate.Y % 2 == 0 ? coordinate.X % 2 == 0 ? _c1 : _c2 : coordinate.X % 2 == 0 ? _c2 : _c1;
        using var g = Graphics.FromImage(_buffer);
        g.FillRectangle(brush, coordinate.X * SquareDimension, coordinate.Y * SquareDimension, SquareDimension, SquareDimension);
        if (piece != null)
        {
            g.DrawImage(piece, coordinate.X * SquareDimension, coordinate.Y * SquareDimension, SquareDimension, SquareDimension);
        }
    }

    //NAVIGATION CODE

    private void GUIView_FormClosing(object sender, FormClosingEventArgs e)
    {
        Program.MainMenu.Show();
    }
}