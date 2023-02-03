using FluentAssertions;
using Shared.Data;

namespace Shared.Test
{
    [TestFixture]
    public class RookTest
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
        public void GetMovementPossibilities_WhenWhiteRookMoves_ReturnCellsWithoutPiece()
        {
            // arrange
            var whiteRook = _whitePieces.First(x => x.StartRow == 0 && x.StartColumn == 0);

            // act
            var result = whiteRook.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(6);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(6);
        }

        [Test]
        public void GetMovementPossibilities_WhenBlackRookMoves_ReturnCellsWithAndWithoutThePiece()
        {
            // arrange
            var blackRook = _blackPieces.First(x => x.StartRow == 7 && x.StartColumn == 3);

            // act
            var result = blackRook.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(7);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(6);
            result.Where(x => x.ContainsPiece == true).Should().HaveCount(1);
        }

        [Test]
        public void GetMovementPossibilities_WhenBlackRookMoves_ReturnAnEmptyListOfCells()
        {
            // arrange
            var blackRook = _blackPieces.First(x => x.StartRow == 7 && x.StartColumn == 7);

            // act
            var result = blackRook.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().BeEmpty();
        }
    }
}
