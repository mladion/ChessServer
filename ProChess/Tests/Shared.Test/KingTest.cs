using FluentAssertions;
using Shared.Data;

namespace Shared.Test
{
    [TestFixture]
    public class KingTest
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
        public void GetMovementPossibilities_WhenWhiteKingMoves_ReturnCellsWithoutPiece()
        {
            // arrange
            var whiteKing = _whitePieces.First(x => x.StartRow == 0 && x.StartColumn == 4);

            // act
            var result = whiteKing.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(5);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(5);
        }

        [Test]
        public void GetMovementPossibilities_WhenBlackKingMoves_ReturnCellsWithoutPiece()
        {
            // arrange
            var blackKing = _blackPieces.First(x => x.StartRow == 7 && x.StartColumn == 4);

            // act
            var result = blackKing.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            // TODO chess -> change HaveCount(2)
            result.Should().HaveCount(3);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(3);
        }
    }
}
