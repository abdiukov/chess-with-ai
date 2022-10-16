using System.Collections.Generic;
using System.Drawing;
using ChessGame.Data;
using ChessGame.Model;

namespace ChessGame.Service;

public class ChessMovementService
{
    private Team _pieceTeam;
    public IList<Point?> GetPossibleMoves(Piece piece, int x, int y)
    {
        //returns the highlighted squares
        return piece.GetMoves(x,y);
    }



}