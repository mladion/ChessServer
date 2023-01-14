using Shared.Rules;

namespace Shared.Data
{
    public class GamePieces
    {
        private List<Piece> _whitePieces = new();
        private List<Piece> _blackPieces = new();

        public List<Piece> InitializationWhitePieces()
        {
            for (int i = 0; i < 8; i++)
            {
                _whitePieces.Add(new Pawn
                {
                    Color = PieceColor.White,
                    Image = "/images/wP.svg",
                    StartColumn = i,
                    StartRow = 1
                });
            }

            _whitePieces.AddRange(new List<Piece>
            {
                //new Piece
                //{
                //    Name = PieceType.Rook,
                //    Color = PieceColor.White,
                //    Image = "/images/wR.svg",
                //    StartColumn = 0,
                //    StartRow = 0
                //},
                //new Piece
                //{
                //    Name = PieceType.Rook,
                //    Color = PieceColor.White,
                //    Image = "/images/wR.svg",
                //    StartColumn = 7,
                //    StartRow = 0
                //},
                new Knight
                {
                    Color = PieceColor.White,
                    Image = "/images/wN.svg",
                    StartColumn = 1,
                    StartRow = 0
                },
                new Knight
                {
                    Color = PieceColor.White,
                    Image = "/images/wN.svg",
                    StartColumn = 6,
                    StartRow = 0
                },
                //new Piece
                //{
                //    Name = PieceType.Bishop,
                //    Color = PieceColor.White,
                //    Image = "/images/wB.svg",
                //    StartColumn = 2,
                //    StartRow = 0
                //},
                //new Piece
                //{
                //    Name = PieceType.Bishop,
                //    Color = PieceColor.White,
                //    Image = "/images/wB.svg",
                //    StartColumn = 5,
                //    StartRow = 0
                //},
                //new Piece
                //{
                //    Name = PieceType.Queen,
                //    Color = PieceColor.White,
                //    Image = "/images/wQ.svg",
                //    StartColumn = 3,
                //    StartRow = 0
                //},
                //new Piece
                //{
                //    Name = PieceType.King,
                //    Color = PieceColor.White,
                //    Image = "/images/wK.svg",
                //    StartColumn = 4,
                //    StartRow = 0
                //}
            });

            return _whitePieces;
        }

        public List<Piece> InitializationBlackPieces()
        {
            for (int i = 0; i < 8; i++)
            {
                _blackPieces.Add(new Pawn
                {
                    Color = PieceColor.Black,
                    Image = "/images/bP.svg",
                    StartColumn = i,
                    StartRow = 6
                });
            }

            _blackPieces.AddRange(new List<Piece>
            {
                //new Piece
                //{
                //    Name = PieceType.Rook,
                //    Color = PieceColor.Black,
                //    Image = "/images/bR.svg",
                //    StartColumn = 0,
                //    StartRow = 7
                //},
                //new Piece
                //{
                //    Name = PieceType.Rook,
                //    Color = PieceColor.Black,
                //    Image = "/images/bR.svg",
                //    StartColumn = 7,
                //    StartRow = 7
                //},
                new Knight
                {
                    Color = PieceColor.Black,
                    Image = "/images/bN.svg",
                    StartColumn = 1,
                    StartRow = 7
                },
                new Knight
                {
                    Color = PieceColor.Black,
                    Image = "/images/bN.svg",
                    StartColumn = 6,
                    StartRow = 7
                },
                //new Piece
                //{
                //    Name = PieceType.Bishop,
                //    Color = PieceColor.Black,
                //    Image = "/images/bB.svg",
                //    StartColumn = 2,
                //    StartRow = 7
                //},
                //new Piece
                //{
                //    Name = PieceType.Bishop,
                //    Color = PieceColor.Black,
                //    Image = "/images/bB.svg",
                //    StartColumn = 5,
                //    StartRow = 7
                //},
                //new Piece
                //{
                //    Name = PieceType.Queen,
                //    Color = PieceColor.Black,
                //    Image = "/images/bQ.svg",
                //    StartColumn = 3,
                //    StartRow = 7
                //},
                //new Piece
                //{
                //    Name = PieceType.King,
                //    Color = PieceColor.Black,
                //    Image = "/images/bK.svg",
                //    StartColumn = 4,
                //    StartRow = 7
                //}
            });

            return _blackPieces;
        }
    }
}
