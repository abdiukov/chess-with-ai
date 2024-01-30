namespace ChessGameTests.Model;

using NUnit.Framework;
using System.Drawing;
using ChessGame.Model;
using System.Collections.Generic;

[TestFixture]
public class RookTests
{
    [Test]
    public void TestGetMoves()
    {
        // Arrange the board (for now, we can assume piece is alone on the board)
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Coordinates.Board[i, j].Piece = null;
            }
        }

        var rook = new Rook(Team.White);

        var expectedMoves = new List<Point?>
        {
            // Horizontal moves to the left and right
            new Point(2, 3), new Point(1, 3), new Point(0, 3),
            new Point(4, 3), new Point(5, 3), new Point(6, 3), new Point(7, 3),
            
            // Vertical moves up and down
            new Point(3, 2), new Point(3, 1), new Point(3, 0),
            new Point(3, 4), new Point(3, 5), new Point(3, 6), new Point(3, 7),
        };

        //Act
        var moves = rook.GetMoves(3, 3);

        //Assert
        CollectionAssert.AreEquivalent(expectedMoves, moves);
    }
}