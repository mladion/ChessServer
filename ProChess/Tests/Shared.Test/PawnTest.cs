using FluentAssertions;
using Shared.Data;

namespace Shared.Test
{
    [TestFixture]
    public class PawnTest
    {
        private List<Piece> _whitePieces { get; set; } = new List<Piece>();
        private List<Piece> _blackPieces { get; set; } = new List<Piece>();

        [OneTimeSetUp]
        public void SetUp()
        {
            var positionTest = new GeneralPositionTest();
            _whitePieces = positionTest.InitializationWhitePieces();
            _blackPieces = positionTest.InitializationBlackPieces();
        }

        [Test]
        public void GetMovementPossibilities_WhenWhitePawnMoves_ReturnCellWithoutPiece()
        {
            // arrange
            var whitePawn = _whitePieces.First(x => x.StartRow == 1 && x.StartColumn == 2);

            // act
            var result = whitePawn.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(1);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(1);
        }

        [Test]
        public void GetMovementPossibilities_WhenWhitePawnMoves_ReturnCellsWithoutThePiece()
        {
            // arrange
            var whitePawn = _whitePieces.First(x => x.StartRow == 1 && x.StartColumn == 6);

            // act
            var result = whitePawn.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(2);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(2);
        }

        [Test]
        public void GetMovementPossibilities_WhenWhitePawnMoves_ReturnCellWithPiece()
        {
            // arrange
            var whitePawn = _whitePieces.First(x => x.StartRow == 5 && x.StartColumn == 7);

            // act
            var result = whitePawn.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(1);
            result.Where(x => x.ContainsPiece == true).Should().HaveCount(1);
        }

        [Test]
        public void GetMovementPossibilities_WhenWhitePawnMoves_ReturnCellsWithAndWithoutThePiece()
        {
            // arrange
            var whitePawn = _whitePieces.First(x => x.StartRow == 4 && x.StartColumn == 0);

            // act
            var result = whitePawn.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(2);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(1);
            result.Where(x => x.ContainsPiece == true).Should().HaveCount(1);
        }

        [Test]
        public void GetMovementPossibilities_WhenWhitePawnMoves_ReturnAnEmptyListOfCells()
        {
            // arrange
            var whitePawn = _whitePieces.First(x => x.StartRow == 1 && x.StartColumn == 5);

            // act
            var result = whitePawn.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().BeEmpty();
        }

        [Test]
        public void GetMovementPossibilities_WhenBlackPawnMoves_ReturnCellWithoutPiece()
        {
            // arrange
            var blackPawn = _blackPieces.First(x => x.StartRow == 6 && x.StartColumn == 0);

            // act
            var result = blackPawn.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(1);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(1);
        }

        [Test]
        public void GetMovementPossibilities_WhenBlackPawnMoves_ReturnCellsWithoutThePiece()
        {
            // arrange
            var blackPawn = _blackPieces.First(x => x.StartRow == 3 && x.StartColumn == 2);

            // act
            var result = blackPawn.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            // to do En Passant Move -> change HaveCount(2)
            result.Should().HaveCount(1);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(1);
        }

        [Test]
        public void GetMovementPossibilities_WhenBlackPawnMoves_ReturnCellWithPiece()
        {
            // arrange
            var blackPawn = _blackPieces.First(x => x.StartRow == 5 && x.StartColumn == 1);

            // act
            var result = blackPawn.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(1);
            result.Where(x => x.ContainsPiece == true).Should().HaveCount(1);
        }

        [Test]
        public void GetMovementPossibilities_WhenBlackPawnMoves_ReturnCellsWithAndWithoutThePiece()
        {
            // arrange
            var blackPawn = _blackPieces.First(x => x.StartRow == 6 && x.StartColumn == 6);

            // act
            var result = blackPawn.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(3);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(2);
            result.Where(x => x.ContainsPiece == true).Should().HaveCount(1);
        }

        [Test]
        public void GetMovementPossibilities_WhenBlackPawnMoves_ReturnAnEmptyListOfCells()
        {
            // arrange
            var blackPawn = _blackPieces.First(x => x.StartRow == 6 && x.StartColumn == 2);

            // act
            var result = blackPawn.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().BeEmpty();
        }
    }
}
