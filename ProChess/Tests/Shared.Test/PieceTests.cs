using FluentAssertions;
using Shared.Data;
using Shared.Rules;

namespace Shared.Test
{
    [TestFixture]
    public class PieceTests
    {
        [Test]
        public void EvaluateCellForMovement_WhenNoPieceOccupiesThatCell_ReturnCellWithoutPiece()
        {
            //arrange
            GamePieces gamePieces = new GamePieces();
            var whitePieces = gamePieces.InitializationWhitePieces();
            var blackPieces = gamePieces.InitializationBlackPieces();
            var pawn = new Pawn();

            //act
            var result = pawn.EvaluateCellForMovement(row: 2, column: 2, whitePieces, blackPieces);

            //assert
            result.Should().NotBeNull();
            result.ContainsPiece.Should().BeFalse();
        }

        [Test]
        public void EvaluateCellForMovement_WhenBlackPieceOccupiesThatCellAndWhiteMovesButIsNotPawn_ReturnCellWithPiece()
        {
            //arrange
            GamePieces gamePieces = new GamePieces();
            var whitePieces = gamePieces.InitializationWhitePieces();
            var blackPieces = gamePieces.InitializationBlackPieces();
            var knight = new Knight();
            knight.Color = PieceColor.White;

            //act
            var result = knight.EvaluateCellForMovement(row: 6, column: 2, whitePieces, blackPieces);

            //assert
            result.Should().NotBeNull();
            result.ContainsPiece.Should().BeTrue();
        }

        [Test]
        public void EvaluateCellForMovement_WhenBlackPieceOccupiesThatCellAndWhiteMovesButIsPawn_ReturnNull()
        {
            //arrange
            GamePieces gamePieces = new GamePieces();
            var whitePieces = gamePieces.InitializationWhitePieces();
            var blackPieces = gamePieces.InitializationBlackPieces();
            var pawn = new Pawn();
            pawn.Color = PieceColor.White;

            //act
            var result = pawn.EvaluateCellForMovement(row: 6, column: 2, whitePieces, blackPieces);

            //assert
            result.Should().BeNull();
        }

        [Test]
        public void EvaluateCellForMovement_WhenWhitePieceOccupiesThatCellAndWhiteMovesButIsNotPawn_ReturnNull()
        {
            //arrange
            GamePieces gamePieces = new GamePieces();
            var whitePieces = gamePieces.InitializationWhitePieces();
            var blackPieces = gamePieces.InitializationBlackPieces();
            var pawn = new Pawn();
            pawn.Color = PieceColor.White;

            //act
            var result = pawn.EvaluateCellForMovement(row: 1, column: 2, whitePieces, blackPieces);

            //assert
            result.Should().BeNull();
        }

        [Test]
        public void EvaluateCellForMovement_WhenWhitePieceOccupiesThatCellAndWhiteMovesButIsPawn_ReturnNull()
        {
            //arrange
            GamePieces gamePieces = new GamePieces();
            var whitePieces = gamePieces.InitializationWhitePieces();
            var blackPieces = gamePieces.InitializationBlackPieces();
            var pawn = new Pawn();
            pawn.Color = PieceColor.White;
            pawn.StartRow = 2;
            pawn.StartColumn = 2;
            whitePieces.Add(pawn);

            //act
            var result = pawn.EvaluateCellForMovement(row: 2, column: 2, whitePieces, blackPieces);

            //assert
            result.Should().BeNull();
        }

        [Test]
        public void EvaluateCellForMovement_WhenWhitePieceOccupiesThatCellAndBlackMovesButIsNotPawn_ReturnCellWithPiece()
        {
            //arrange
            GamePieces gamePieces = new GamePieces();
            var whitePieces = gamePieces.InitializationWhitePieces();
            var blackPieces = gamePieces.InitializationBlackPieces();
            var knight = new Knight();
            knight.Color = PieceColor.Black;

            //act
            var result = knight.EvaluateCellForMovement(row: 1, column: 2, whitePieces, blackPieces);

            //assert
            result.Should().NotBeNull();
            result.ContainsPiece.Should().BeTrue();
        }

        [Test]
        public void EvaluateCellForMovement_WhenWhitePieceOccupiesThatCellAndBlackMovesButIsPawn_ReturnNull()
        {
            //arrange
            GamePieces gamePieces = new GamePieces();
            var whitePieces = gamePieces.InitializationWhitePieces();
            var blackPieces = gamePieces.InitializationBlackPieces();
            var pawn = new Pawn();
            pawn.Color = PieceColor.Black;

            //act
            var result = pawn.EvaluateCellForMovement(row: 1, column: 2, whitePieces, blackPieces);

            //assert
            result.Should().BeNull();
        }

        [Test]
        public void EvaluateCellForMovement_WhenBlackPieceOccupiesThatCellAndBlackMovesButIsNotPawn_ReturnNull()
        {
            //arrange
            GamePieces gamePieces = new GamePieces();
            var whitePieces = gamePieces.InitializationWhitePieces();
            var blackPieces = gamePieces.InitializationBlackPieces();
            var knight = new Knight();
            knight.Color = PieceColor.Black;

            //act
            var result = knight.EvaluateCellForMovement(row: 6, column: 2, whitePieces, blackPieces);

            //assert
            result.Should().BeNull();
        }

        [Test]
        public void EvaluateCellForMovement_WhenBlackPieceOccupiesThatCellAndBlackMovesButIsPawn_ReturnNull()
        {
            //arrange
            GamePieces gamePieces = new GamePieces();
            var whitePieces = gamePieces.InitializationWhitePieces();
            var blackPieces = gamePieces.InitializationBlackPieces();
            var pawn = new Pawn();
            pawn.Color = PieceColor.Black;
            pawn.StartRow = 5;
            pawn.StartColumn = 2;
            blackPieces.Add(pawn);

            //act
            var result = pawn.EvaluateCellForMovement(row: 5, column: 2, whitePieces, blackPieces);

            //assert
            result.Should().BeNull();
        }

        [Test]
        public void MoveOrAttack_WhenThatCellContainsPiece_DeleteThePieceAndChangeTheCoordinatesOfTheActivePiece()
        {
            //arrange
            var queen = new Queen();
            queen.Color = PieceColor.White;
            queen.StartRow = 5;
            queen.StartColumn = 0;
            var cell = new Cell(row: 5, column: 5, true);

            var blackPieces = new List<Piece>();
            var bishop = new Bishop();
            bishop.Color = PieceColor.Black;
            bishop.StartRow = 5;
            bishop.StartColumn = 5;
            blackPieces.Add(bishop);

            //act
            queen.MoveOrAttack(cell, blackPieces);

            //assert
            blackPieces.Should().BeEmpty();
            queen.StartRow.Should().Be(cell.Row);
            queen.StartColumn.Should().Be(cell.Column);
        }

        [Test]
        public void MoveOrAttack_WhenThatFieldIsEmpty_ChangeTheCoordinatesOfTheActivePiece()
        {
            //arrange
            var queen = new Queen();
            queen.Color = PieceColor.White;
            queen.StartRow = 0;
            queen.StartColumn = 5;
            var cell = new Cell(row: 4, column: 5, true);

            var blackPieces = new List<Piece>();
            var bishop = new Bishop();
            bishop.Color = PieceColor.Black;
            bishop.StartRow = 5;
            bishop.StartColumn = 5;
            blackPieces.Add(bishop);

            //act
            queen.MoveOrAttack(cell, blackPieces);

            //assert
            blackPieces.Should().NotBeEmpty();
            queen.StartRow.Should().Be(cell.Row);
            queen.StartColumn.Should().Be(cell.Column);
        }
    }
}
