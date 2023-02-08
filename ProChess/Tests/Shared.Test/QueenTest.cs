using FluentAssertions;
using Shared.Data;

namespace Shared.Test
{
    [TestFixture]
    public class QueenTest
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
        public void GetMovementPossibilities_WhenWhiteQueenMoves_ReturnCellsWithoutPiece()
        {
            // arrange
            var whiteQueen = _whitePieces.First(x => x.StartRow == 2 && x.StartColumn == 7);

            // act
            var result = whiteQueen.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(9);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(9);
        }

        [Test]
        public void GetMovementPossibilities_WhenBlackQueenMoves_ReturnCellsWithAndWithoutThePiece()
        {
            // arrange
            var blackQueen = _blackPieces.First(x => x.StartRow == 4 && x.StartColumn == 1);

            // act
            var result = blackQueen.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(12);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(10);
            result.Where(x => x.ContainsPiece == true).Should().HaveCount(2);
        }
    }
}
