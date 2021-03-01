using System;
using System.Drawing;

namespace Chess
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

    public class MoveDiagonal : Move
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

    public class MoveLinear : Move
    {
        public MoveLinear() : base() { }
        public MoveLinear(int limit) : base(limit) { }
        public override bool isValid(Point origin, Point destination)
        {
            if (destination.X == origin.X || destination.Y == origin.Y)
            {
                return Distance(origin, destination) <= limit;
            }
            return false;
        }
    }

    public class MoveLinearOnce : MoveLinear
    {
        private Pawn owner;
        public MoveLinearOnce(int limit, Pawn owner) : base(limit) { this.owner = owner; }

        public override void Execute()
        {
            owner.FirstMove();
        }

        public override bool isValid(Point origin, Point destination)
        {
            if (destination.X != origin.X || destination.Y != origin.Y)
            {
                return Distance(origin, destination) <= limit;
            }
            return false;
        }


    }

    public class MoveOrthogonal : Move
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
