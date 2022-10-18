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
            var isEmpty = IsEmpty(xValue, yValue, this);

            if (isEmpty == true)
                output.Add(new Point(xValue, yValue));
            else if (isEmpty == false)
            {
                output.Add(new Point(xValue, yValue));
                break;
            }
            else
                break;
        }

        //right up
        for (int xValue = x + 1, yValue = y - 1, exitLoop = 0; exitLoop == 0; xValue++, yValue--)
        {
            var isEmpty = IsEmpty(xValue, yValue, this);

            if (isEmpty == true)
                output.Add(new Point(xValue, yValue));
            else if (isEmpty == false)
            {
                output.Add(new Point(xValue, yValue));
                break;
            }
            else
                break;
        }


        //left up
        for (int xValue = x - 1, yValue = y - 1, exitLoop = 0; exitLoop == 0; xValue--, yValue--)
        {
            var isEmpty = IsEmpty(xValue, yValue, this);

            if (isEmpty == true)
                output.Add(new Point(xValue, yValue));
            else if (isEmpty == false)
            {
                output.Add(new Point(xValue, yValue));
                break;
            }
            else
                break;
        }

        //left down
        for (int xValue = x - 1, yValue = y + 1, exitLoop = 0; exitLoop == 0; xValue--, yValue++)
        {
            var isEmpty = IsEmpty(xValue, yValue, this);

            if (isEmpty == true)
                output.Add(new Point(xValue, yValue));
            else if (isEmpty == false)
            {
                output.Add(new Point(xValue, yValue));
                break;
            }
            else
                break;
        }

        return output;
    }
}