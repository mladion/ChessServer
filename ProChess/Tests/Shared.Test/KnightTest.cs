using FluentAssertions;
using Shared.Data;

namespace Shared.Test
{
    [TestFixture]
    public class KnightTest
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
        public void GetMovementPossibilities_WhenWhiteKnightMoves_ReturnCellsWithoutPiece()
        {
            // arrange
            var whiteKnight = _whitePieces.First(x => x.StartRow == 2 && x.StartColumn == 5);

            // act
            var result = whiteKnight.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(6);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(6);
        }

        [Test]
        public void GetMovementPossibilities_WhenBlackKnightMoves_ReturnCellsWithAndWithoutThePiece()
        {
            // arrange
            var blackKnight = _blackPieces.First(x => x.StartRow == 7 && x.StartColumn == 6);

            // act
            var result = blackKnight.GetMovementPossibilities(_whitePieces, _blackPieces);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(3);
            result.Where(x => x.ContainsPiece == false).Should().HaveCount(2);
            result.Where(x => x.ContainsPiece == true).Should().HaveCount(1);
        }
    }
}
