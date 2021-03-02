namespace Models
{
    public abstract class Piece
    {
        protected Piece(int team)
        {
            Team = team;
        }

        int Team { get; set; } // 0 is white, 1 is black
        void MoveToEmpty() {; }
        void Take() {; }
    }
}
