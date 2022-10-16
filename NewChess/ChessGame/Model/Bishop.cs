using System.Collections.Generic;
using System.Drawing;

namespace ChessGame.Model;

public class Bishop : Piece
{
    public Bishop(Team team)
        : base(team, "Bishop") { }


    public override IList<Point?> GetMoves(int x, int y)
    {
        List<Point?> output = new();

        //right down

        for (int xValue = x + 1, yValue = y + 1, exitLoop = 0; exitLoop == 0; xValue++, yValue++)
        {
            switch (IsEmpty(xValue, yValue, this))
            {
                case true:
                    output.Add(new Point(xValue, yValue));
                    break;
                case false:
                    output.Add(new Point(xValue, yValue));
                    exitLoop = 1;
                    break;
                case null:
                    exitLoop = 1;
                    break;
            }
        }

        //right up
        for (int xValue = x + 1, yValue = y - 1, exitLoop = 0; exitLoop == 0; xValue++, yValue--)
        {
            switch (IsEmpty(xValue, yValue, this))
            {
                case true:
                    output.Add(new Point(xValue, yValue));
                    break;
                case false:
                    output.Add(new Point(xValue, yValue));
                    exitLoop = 1;
                    break;
                case null:
                    exitLoop = 1;
                    break;
            }
        }


        //left up
        for (int xValue = x - 1, yValue = y - 1, exitLoop = 0; exitLoop == 0; xValue--, yValue--)
        {

            switch (IsEmpty(xValue, yValue, this))
            {
                case true:
                    output.Add(new Point(xValue, yValue));
                    break;
                case false:
                    output.Add(new Point(xValue, yValue));
                    exitLoop = 1;
                    break;
                case null:
                    exitLoop = 1;
                    break;
            }
        }

        //left down

        for (int xValue = x - 1, yValue = y + 1, exitLoop = 0; exitLoop == 0; xValue--, yValue++)
        {
            switch (IsEmpty(xValue, yValue, this))
            {
                case true:
                    output.Add(new Point(xValue, yValue));
                    break;
                case false:
                    output.Add(new Point(xValue, yValue));
                    exitLoop = 1;
                    break;
                case null:
                    exitLoop = 1;
                    break;
            }
        }

        return output;
    }
}