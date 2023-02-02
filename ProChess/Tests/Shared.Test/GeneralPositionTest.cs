using Shared.Data;
using Shared.Rules;

namespace Shared.Test
{
    public class GeneralPositionTest
    {
        private List<Piece> _whitePieces = new();
        private List<Piece> _blackPieces = new();

        public List<Piece> InitializationWhitePieces()
        {
            _whitePieces.AddRange(new List<Piece>
            {
                new Pawn
                {
                    Color = PieceColor.White,
                    Image = "/images/wP.svg",
                    StartRow = 4,
                    StartColumn = 0
                },
                new Pawn
                {
                    Color = PieceColor.White,
                    Image = "/images/wP.svg",
                    StartRow = 1,
                    StartColumn = 2
                },
                new Pawn
                {
                    Color = PieceColor.White,
                    Image = "/images/wP.svg",
                    StartRow = 3,
                    StartColumn = 3
                },
                new Pawn
                {
                    Color = PieceColor.White,
                    Image = "/images/wP.svg",
                    StartRow = 2,
                    StartColumn = 4
                },
                new Pawn
                {
                    Color = PieceColor.White,
                    Image = "/images/wP.svg",
                    StartRow = 1,
                    StartColumn = 5
                },
                new Pawn
                {
                    Color = PieceColor.White,
                    Image = "/images/wP.svg",
                    StartRow = 1,
                    StartColumn = 6
                },
                new Pawn
                {
                    Color = PieceColor.White,
                    Image = "/images/wP.svg",
                    StartRow = 5,
                    StartColumn = 7
                },
                new Rook
                {
                    Color = PieceColor.White,
                    Image = "/images/wR.svg",
                    StartColumn = 0,
                    StartRow = 0
                },
                new Rook
                {
                    Color = PieceColor.White,
                    Image = "/images/wR.svg",
                    StartColumn = 7,
                    StartRow = 0
                },
                new Knight
                {
                    Color = PieceColor.White,
                    Image = "/images/wN.svg",
                    StartRow = 2,
                    StartColumn = 5
                },
                new Bishop
                {
                    Color = PieceColor.White,
                    Image = "/images/wB.svg",
                    StartRow = 1,
                    StartColumn = 1
                },
                new Bishop
                {
                    Color = PieceColor.White,
                    Image = "/images/wB.svg",
                    StartRow = 1,
                    StartColumn = 4
                },
                new Queen
                {
                    Color = PieceColor.White,
                    Image = "/images/wQ.svg",
                    StartRow = 2,
                    StartColumn = 7
                },
                new King
                {
                    Color = PieceColor.White,
                    Image = "/images/wK.svg",
                    StartColumn = 4,
                    StartRow = 0
                }
            });

            return _whitePieces;
        }

        public List<Piece> InitializationBlackPieces()
        {
            _blackPieces.AddRange(new List<Piece>
            {
                new Pawn
                {
                    Color = PieceColor.Black,
                    Image = "/images/bP.svg",
                    StartRow = 6,
                    StartColumn = 0
                },
                new Pawn
                {
                    Color = PieceColor.Black,
                    Image = "/images/bP.svg",
                    StartRow = 5,
                    StartColumn = 1
                },
                new Pawn
                {
                    Color = PieceColor.Black,
                    Image = "/images/bP.svg",
                    StartRow = 6,
                    StartColumn = 2
                },
                new Pawn
                {
                    Color = PieceColor.Black,
                    Image = "/images/bP.svg",
                    StartRow = 3,
                    StartColumn = 2
                },
                new Pawn
                {
                    Color = PieceColor.Black,
                    Image = "/images/bP.svg",
                    StartRow = 6,
                    StartColumn = 6
                },
                new Pawn
                {
                    Color = PieceColor.Black,
                    Image = "/images/bP.svg",
                    StartRow = 6,
                    StartColumn = 7
                },
                new Rook
                {
                    Color = PieceColor.Black,
                    Image = "/images/bR.svg",
                    StartRow = 7,
                    StartColumn = 0
                },
                new Rook
                {
                    Color = PieceColor.Black,
                    Image = "/images/bR.svg",
                    StartRow = 7,
                    StartColumn = 7
                },
                new Knight
                {
                    Color = PieceColor.Black,
                    Image = "/images/bN.svg",
                    StartRow = 7,
                    StartColumn = 6
                },
                new Bishop
                {
                    Color = PieceColor.Black,
                    Image = "/images/bB.svg",
                    StartRow = 5,
                    StartColumn = 2
                },
                new Bishop
                {
                    Color = PieceColor.Black,
                    Image = "/images/bB.svg",
                    StartRow = 7,
                    StartColumn = 5
                },
                new Queen
                {
                    Color = PieceColor.Black,
                    Image = "/images/bQ.svg",
                    StartRow = 4,
                    StartColumn = 1,
                },
                new King
                {
                    Color = PieceColor.Black,
                    Image = "/images/bK.svg",
                    StartRow = 7,
                    StartColumn = 4
                }
            });

            return _blackPieces;
        }
    }
}
