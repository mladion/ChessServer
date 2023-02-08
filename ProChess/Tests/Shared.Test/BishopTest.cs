using FluentAssertions;
using Shared.Data;

namespace Shared.Test
{
    [TestFixture]
    public class BishopTest
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
        public void GetMovementPossibilities_WhenWhiteBishopMoves_ReturnCellsWithoutPiece()
        {
            // arrange
            var whiteBishop = _whitePieces.First(x => x.StartRow == 1 && x.StartColumn == 1);

            // act
            var result = whiteBishop.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(3);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(3);
        }

        [Test]
        public void GetMovementPossibilities_WhenWhiteBishopMoves_ReturnCellsWithAndWithoutThePiece()
        {
            // arrange
            var whiteBishop = _whitePieces.First(x => x.StartRow == 1 && x.StartColumn == 4);

            // act
            var result = whiteBishop.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(4);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(3);
            result.Where(x => x.ContainsPiece == true).Should().HaveCount(1);
        }

        [Test]
        public void GetMovementPossibilities_WhenBlackBishopMoves_ReturnCellsWithoutPiece()
        {
            // arrange
            var blackBishop = _blackPieces.First(x => x.StartRow == 7 && x.StartColumn == 5);

            // act
            var result = blackBishop.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(5);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(5);
        }

        [Test]
        public void GetMovementPossibilities_WhenBlackBishopMoves_ReturnCellsWithAndWithoutThePiece()
        {
            // arrange
            var blackBishop = _blackPieces.First(x => x.StartRow == 5 && x.StartColumn == 2);

            // act
            var result = blackBishop.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(6);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(5);
            result.Where(x => x.ContainsPiece == true).Should().HaveCount(1);
        }
    }
}

