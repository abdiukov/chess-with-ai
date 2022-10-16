using System;
using System.Collections.Generic;
using System.Drawing;

namespace ChessGame.Model;

public class Queen : Piece
{
    public Queen(Team team)
        : base(team, "Queen") { }

    public override IList<Point?> GetMoves(int x, int y)
    {
        List<Point?> output = new();


        // TODO: Implement
        //output.AddRange(Bishop.GetMoves(x, y));
        //output.AddRange(Rook.GetMoves(x, y));

        return new List<Point?>();
    }
}