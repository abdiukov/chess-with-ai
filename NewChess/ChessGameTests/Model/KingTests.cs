namespace ChessGameTests.Model;

using NUnit.Framework;
using System.Drawing;
using ChessGame.Model;
using System.Collections.Generic;

[TestFixture]
public class KingTests
{
    [Test]
    public void TestGetMoves()
    {
        //Arrange
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Coordinates.Board[i, j] = new Square();
            }
        }

        var king = new King(Team.White);

        var expectedMoves = new List<Point?>
        {
            // all moves around the King
            new Point(3, 2),  // up
            new Point(3, 4),  // down
            new Point(2, 3),  // left
            new Point(4, 3),  // right
            new Point(2, 2),  // left-up
            new Point(2, 4),  // left-down
            new Point(4, 2),  // right-up
            new Point(4, 4)  // right-down
        };

        //Act
        var moves = king.GetMoves(3, 3);

        //Assert
        CollectionAssert.AreEquivalent(expectedMoves, moves);
    }
}