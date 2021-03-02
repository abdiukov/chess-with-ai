using System;
using System.Drawing;

namespace Movement
{
    public abstract class Move
    {
        protected readonly int limit;

        public Move() : this(int.MaxValue) { }
        public Move(int limit)
        {
            this.limit = limit;
        }

        public abstract bool isValid(Point origin, Point destination);

        public virtual void Execute() { }

        protected int Distance(Point origin, Point destination)
        {
            return (int)Math.Sqrt(Math.Pow(destination.X - origin.X, 2) + Math.Pow(destination.Y - origin.Y, 2));
        }
    }
}
