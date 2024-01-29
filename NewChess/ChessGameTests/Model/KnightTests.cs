namespace ChessGameTests.Model;

using NUnit.Framework;
using System.Drawing;
using ChessGame.Model;
using System.Collections.Generic;

[TestFixture]
public class KnightTests
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

        var knight = new Knight(Team.White);

        var expectedMoves = new List<Point?> 
        {
            // up right and left
            new Point(4, 1),
            new Point(2, 1),
            // down right and left
            new Point(4, 5),
            new Point(2, 5),
            // left up and down
            new Point(1, 2),
            new Point(1, 4),
            // right up and down
            new Point(5, 2),
            new Point(5, 4)
        };

        //Act
        var moves = knight.GetMoves(3, 3);

        //Assert
        CollectionAssert.AreEquivalent(expectedMoves, moves);
    }
}
