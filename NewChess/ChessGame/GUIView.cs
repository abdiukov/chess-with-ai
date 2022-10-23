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
    private Bitmap _buffer;
    private Point? _selectedSquare;
    private readonly Brush _brushColorOne;
    private readonly Brush _brushColorTwo;
    public IList<Point?> PossibleMoves = new List<Point?>();
    public Controller Controller { get; set; }

    //INITIALIZATION CODE

    public GuiView(Controller controller = null,
        Brush brushColorOne = null, Brush brushColorTwo = null)
    {
        Controller = controller ?? new Controller(this);
        _brushColorOne = brushColorOne ?? Brushes.BlanchedAlmond;
        _brushColorTwo = brushColorTwo ?? Brushes.Silver;

        InitializeComponent();
        InitializeGraphics();
        Controller.Handle(new StartGameCommand());

        MouseClick += GUIView_MouseClick;
        Program.GameWindow = this;
    }

    private void InitializeGraphics()
    {
        MaximumSize = new Size(_dimension, _dimension);
        MinimumSize = new Size(_dimension / 2, _dimension / 2);
        _buffer = new Bitmap(BufferDimension, BufferDimension);
        Size = MaximumSize;
        Paint += GUIView_Paint;
        Resize += GUIView_Resize;
    }

    //RESPOND TO USER INPUT CODE

    public new void Handle(ViewCommand command) { command.Execute(this); }

    private void GUIView_MouseClick(object sender, MouseEventArgs mouseEventArgs)
    {
        Point? coordinate = new Point(mouseEventArgs.X / (ClientSize.Width / 8),
            mouseEventArgs.Y / (ClientSize.Height / 8));
        SelectSquareCommand selectCommand = new(coordinate.Value);

        //creates the command and says to model - go handle that command
        Controller.Handle(selectCommand);

        //if its successful, create selected square
        _selectedSquare = selectCommand.Success ? coordinate : null;

        Invalidate();
    }

    //RESIZE CODE
    private void GUIView_Resize(object sender, EventArgs eventArgs)
    {
        if (WindowState == FormWindowState.Minimized)
            return;

        Height = Width;
        Invalidate();
    }

    //DRAW GRAPHICS CODE

    private void GUIView_Paint(object sender, PaintEventArgs paintEventArgs)
    {
        var x = ClientSize.Width / 8;
        var y = ClientSize.Height / 8;
        var lineSize = (x + y / 2) / 25;
        paintEventArgs.Graphics.DrawImage(_buffer, 0, 0, ClientSize.Width, ClientSize.Height);

        if (_selectedSquare != null)
        {
            var highlight = _selectedSquare.Value;
            paintEventArgs.Graphics.DrawRectangle(new Pen(Color.Yellow, lineSize),
                highlight.X * x, highlight.Y * y, x, y);
        }

        foreach (Point highlight in PossibleMoves)
        {
            paintEventArgs.Graphics.DrawRectangle(new Pen(Color.Green, lineSize),
                highlight.X * x, highlight.Y * y, x, y);
        }
    }

    public void DrawSquare(Image piece, Point coordinate)
    {
        var brush = coordinate.Y % 2 == 0
            ? coordinate.X % 2 == 0
                ? _brushColorOne : _brushColorTwo : coordinate.X % 2 == 0
                ? _brushColorTwo : _brushColorOne;

        using var graphics = Graphics.FromImage(_buffer);
        graphics.FillRectangle(brush, coordinate.X * SquareDimension, coordinate.Y * SquareDimension,
            SquareDimension, SquareDimension);

        if (piece != null)
        {
            graphics.DrawImage(piece, coordinate.X * SquareDimension, coordinate.Y * SquareDimension,
                SquareDimension, SquareDimension);
        }
    }

    //NAVIGATION CODE
    private void GUIView_FormClosing(object sender, FormClosingEventArgs e) => Program.MainMenu.Show();
}