using ChessGame.Model;

namespace ChessGameTests.Model;

[TestFixture]
public class PieceTests
{
    [Test]
    public void TestIsEmpty()
    {
        // Arrange 
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Coordinates.Board[i, j] = new Square();
            }
        }

        Coordinates.Board[3, 3].Piece = new Pawn(Team.White);
        var pawn = new Pawn(Team.White);

        // Act
        var result1 = pawn.IsEmpty(3, 3, pawn);    // should return null because the space is not empty and the piece belongs to the same team
        var result2 = pawn.IsEmpty(0, 0, pawn);    // should return true because the space is empty
        var result3 = pawn.IsEmpty(8, 8, pawn);    // should return null because it's out of the board bounds

        // Assert
        Assert.IsNull(result1);
        Assert.IsTrue(result2);
        Assert.IsNull(result3);
    }

    [Test]
    public void TestIsFriendlyRook()
    {
        // Arrange 
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Coordinates.Board[i, j] = new Square();
            }
        }
        var piece = new Rook(Team.White);
        // Insert a White Rook at (3,3)
        Coordinates.Board[3, 3].Piece = piece;

        var pawn = new Pawn(Team.White);

        //Act
        var result1 = pawn.IsFriendlyRook(3, 3, pawn); // should return true because there is a friendly Rook at that position
        var result2 = pawn.IsFriendlyRook(0, 0, pawn); // should return false because the position is empty
        var result3 = pawn.IsFriendlyRook(8, 8, pawn); // should return false because it's out of the board bounds

        //Assert
        Assert.IsTrue(result1);
        Assert.IsFalse(result2);
        Assert.IsFalse(result3);
    }
}