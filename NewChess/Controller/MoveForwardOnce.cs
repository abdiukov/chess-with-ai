using System.Drawing;

namespace Controller
{
    class MoveForwardOnce : Move
    {
        public MoveForwardOnce() : base() { }
        public MoveForwardOnce(int limit) : base(limit) { }
        public override bool isValid(Point origin, Point destination)
        {
            if (destination.X == origin.X || destination.Y == origin.Y + 1)
            {
                return Distance(origin, destination) <= limit;
            }
            return false;
        }

    }
}
