namespace ChessGameTests.Model;

using NUnit.Framework;
using System.Drawing;
using ChessGame.Model;
using System.Collections.Generic;

[TestFixture]
public class PawnTests
{
    [Test]
    public void TestGetMovesWhitePawn()
    {
        //Arrange
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++) 
            {
                Coordinates.Board[i, j] = new Square();
            }
        }

        var pawn = new Pawn(Team.White);

        var expectedMoves = new List<Point?> 
        {
            new Point(3, 2)
        };

        //Act
        var moves = pawn.GetMoves(3, 3);

        //Assert
        CollectionAssert.AreEquivalent(expectedMoves, moves);
    }

    [Test]
    public void TestGetMovesBlackPawn()
    {
        //Arrange
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++) 
            {
                Coordinates.Board[i, j] = new Square();
            }
        }

        var pawn = new Pawn(Team.Black);

        var expectedMoves = new List<Point?> 
        {
            new Point(3, 4)
        };

        //Act
        var moves = pawn.GetMoves(3, 3);

        //Assert
        CollectionAssert.AreEquivalent(expectedMoves, moves);
    }
}