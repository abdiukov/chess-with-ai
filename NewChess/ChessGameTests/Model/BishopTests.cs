using System.Drawing;
using ChessGame.Model;
using Moq;

namespace ChessGameTests.Model;

public class BishopTests
{
    [Test]
    public void TestGetMoves()
    {
        // Arrange
        // Clear the board
        for (int i = 0; i < 8; i++) 
        {
            for (int j = 0; j < 8; j++)
            {
                Coordinates.Board[i, j] = new Square();
            }
        }

        var bishop = new Bishop(Team.White);
        var expectedMoves = new List<Point?>
        {
            // right down
            new Point(4, 4),
            new Point(5, 5),
            new Point(6, 6),
            new Point(7, 7),
        
            // right up
            new Point(4, 2),
            new Point(5, 1),
            new Point(6, 0),
        
            // left up
            new Point(2, 2),
            new Point(1, 1),
            new Point(0, 0),
        
            // left down
            new Point(2, 4),
            new Point(1, 5),
            new Point(0, 6)
        };

        // Act
        var moves = bishop.GetMoves(3, 3);

        // Assert
        CollectionAssert.AreEquivalent(expectedMoves, moves);
    }
    
}

