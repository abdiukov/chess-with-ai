using System.Collections.Generic;
using System.Drawing;

namespace ChessGame.Model;

public class Queen : Piece
{
    public Queen(Team team)
        : base(team, "Queen") { }

    public override IList<Point?> GetMoves(int x, int y)
    {
        var moves = new List<Point?>();

        //checking moves from the left
        for (var i = x - 1;; i--)
        {
            var isEmpty = IsEmpty(i, y, this);

            if (isEmpty == true)
                moves.Add(new Point(i, y));
            else if (isEmpty == false)
            {
                moves.Add(new Point(i, y));
                break;
            }
            else
                break;

        }

        //checking moves from the right
        for (var i = x + 1;; i++)
        {
            var isEmpty = IsEmpty(i, y, this);

            if (isEmpty == true)
                moves.Add(new Point(i, y));
            else if (isEmpty == false)
            {
                moves.Add(new Point(i, y));
                break;
            }
            else
                break;
        }

        //checking moves from above
        for (var i = y - 1;; i--)
        {
            var isEmpty = IsEmpty(x, i, this);

            if (isEmpty == true)
                moves.Add(new Point(x, i));
            else if (isEmpty == false)
            {
                moves.Add(new Point(x, i));
                break;
            }
            else
                break;
        }

        //checking moves from below
        for (var i = y + 1;; i++)
        {
            var isEmpty = IsEmpty(x, i, this);

            if (isEmpty == true)
                moves.Add(new Point(x, i));
            else if (isEmpty == false)
            {
                moves.Add(new Point(x, i));
                break;
            }
            else
                break;
        }

        for (int xValue = x + 1, yValue = y + 1;; xValue++, yValue++)
        {
            var isEmpty = IsEmpty(xValue, yValue, this);

            if (isEmpty == true)
                moves.Add(new Point(xValue, yValue));
            else if (isEmpty == false)
            {
                moves.Add(new Point(xValue, yValue));
                break;
            }
            else
                break;
        }

        //right up
        for (int xValue = x + 1, yValue = y - 1;; xValue++, yValue--)
        {
            var isEmpty = IsEmpty(xValue, yValue, this);

            if (isEmpty == true)
                moves.Add(new Point(xValue, yValue));
            else if (isEmpty == false)
            {
                moves.Add(new Point(xValue, yValue));
                break;
            }
            else
                break;
        }


        //left up
        for (int xValue = x - 1, yValue = y - 1;; xValue--, yValue--)
        {
            var isEmpty = IsEmpty(xValue, yValue, this);

            if (isEmpty == true)
                moves.Add(new Point(xValue, yValue));
            else if (isEmpty == false)
            {
                moves.Add(new Point(xValue, yValue));
                break;
            }
            else
                break;
        }

        //left down
        for (int xValue = x - 1, yValue = y + 1;; xValue--, yValue++)
        {
            var isEmpty = IsEmpty(xValue, yValue, this);

            if (isEmpty == true)
                moves.Add(new Point(xValue, yValue));
            else if (isEmpty == false)
            {
                moves.Add(new Point(xValue, yValue));
                break;
            }
            else
                break;
        }

        //return all the moves
        return moves;
    }
}