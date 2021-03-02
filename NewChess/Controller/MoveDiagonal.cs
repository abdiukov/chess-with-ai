using System;
using System.Drawing;

namespace Controller
{
    class MoveDiagonal : Move
    {
        public MoveDiagonal() : base() { }
        public MoveDiagonal(int limit) : base(limit) { }
        public override bool isValid(Point origin, Point destination)
        {
            if (Math.Abs(destination.X - origin.X) == Math.Abs(destination.Y - origin.Y))
            {
                return Distance(origin, destination) <= limit;
            }
            return false;
        }
    }
}
