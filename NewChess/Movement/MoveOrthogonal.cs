using System;
using System.Drawing;

namespace Movement
{
    class MoveOrthogonal : Move
    {
        public MoveOrthogonal() : base() { }
        public override bool isValid(Point origin, Point destination)
        {
            int x = Math.Abs(destination.X - origin.X);
            int y = Math.Abs(destination.Y - origin.Y);
            return ((x == 1) && (y == 2)) || ((y == 1) && (x == 2));
        }
    }
}
