using Client.Data;

namespace Client.Components.Board
{
    public partial class Chessboard
    {
        public readonly string[] HorizontalAxis = { "a", "b", "c", "d", "e", "f", "g", "h" };
        public readonly string[] VerticalAxis = { "1", "2", "3", "4", "5", "6", "7", "8" };

        public List<Piece> WhitePieces { get; set; } = new List<Piece>();
        public List<Piece> BlackPieces { get; set; } = new List<Piece>();

        Piece? activePiece = null;

        List<int> rowsPossible = new List<int>();
        List<int> columnsPossible = new List<int>();
        protected override void OnInitialized()
        {
            for (int i = 0; i < 8; i++)
            {
                WhitePieces.Add(new Piece
                {
                    Name = PieceType.Pawn,
                    Color = PieceColor.White,
                    Direction = PieceDirection.Up,
                    Image = "/images/wP.svg",
                    StartPositionX = i,
                    StartPositionY = 1
                });

                BlackPieces.Add(new Piece
                {
                    Name = PieceType.Pawn,
                    Color = PieceColor.Black,
                    Direction = PieceDirection.Down,
                    Image = "/images/bP.svg",
                    StartPositionX = i,
                    StartPositionY = 6
                });
            }

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    BlackPieces.AddRange(new List<Piece>
                    {
                        new Piece
                        {
                            Name = PieceType.Rook,
                            Color = PieceColor.Black,
                            Direction = PieceDirection.All,
                            Image = "/images/bR.svg",
                            StartPositionX = 0,
                            StartPositionY = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Rook,
                            Color = PieceColor.Black,
                            Direction = PieceDirection.All,
                            Image = "/images/bR.svg",
                            StartPositionX = 7,
                            StartPositionY = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Knight,
                            Color = PieceColor.Black,
                            Direction = PieceDirection.All,
                            Image = "/images/bN.svg",
                            StartPositionX = 1,
                            StartPositionY = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Knight,
                            Color = PieceColor.Black,
                            Direction = PieceDirection.All,
                            Image = "/images/bN.svg",
                            StartPositionX = 6,
                            StartPositionY = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Bishop,
                            Color = PieceColor.Black,
                            Direction = PieceDirection.All,
                            Image = "/images/bB.svg",
                            StartPositionX = 2,
                            StartPositionY = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Bishop,
                            Color = PieceColor.Black,
                            Direction = PieceDirection.All,
                            Image = "/images/bB.svg",
                            StartPositionX = 5,
                            StartPositionY = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Queen,
                            Color = PieceColor.Black,
                            Direction = PieceDirection.All,
                            Image = "/images/bQ.svg",
                            StartPositionX = 3,
                            StartPositionY = 7
                        },
                        new Piece
                        {
                            Name = PieceType.King,
                            Color = PieceColor.Black,
                            Direction = PieceDirection.All,
                            Image = "/images/bK.svg",
                            StartPositionX = 4,
                            StartPositionY = 7
                        }
                    });
                }
                else
                {
                    WhitePieces.AddRange(new List<Piece>
                    {
                        new Piece
                        {
                            Name = PieceType.Rook,
                            Color = PieceColor.White,
                            Direction = PieceDirection.All,
                            Image = "/images/wR.svg",
                            StartPositionX = 0,
                            StartPositionY = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Rook,
                            Color = PieceColor.White,
                            Direction = PieceDirection.All,
                            Image = "/images/wR.svg",
                            StartPositionX = 7,
                            StartPositionY = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Knight,
                            Color = PieceColor.White,
                            Direction = PieceDirection.All,
                            Image = "/images/wN.svg",
                            StartPositionX = 1,
                            StartPositionY = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Knight,
                            Color = PieceColor.White,
                            Direction = PieceDirection.All,
                            Image = "/images/wN.svg",
                            StartPositionX = 6,
                            StartPositionY = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Bishop,
                            Color = PieceColor.White,
                            Direction = PieceDirection.All,
                            Image = "/images/wB.svg",
                            StartPositionX = 2,
                            StartPositionY = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Bishop,
                            Color = PieceColor.White,
                            Direction = PieceDirection.All,
                            Image = "/images/wB.svg",
                            StartPositionX = 5,
                            StartPositionY = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Queen,
                            Color = PieceColor.White,
                            Direction = PieceDirection.All,
                            Image = "/images/wQ.svg",
                            StartPositionX = 3,
                            StartPositionY = 0
                        },
                        new Piece
                        {
                            Name = PieceType.King,
                            Color = PieceColor.White,
                            Direction = PieceDirection.All,
                            Image = "/images/wK.svg",
                            StartPositionX = 4,
                            StartPositionY = 0
                        }
                    });
                }
            }
        }

        private void EvaluatePieceSpots()
        {
            rowsPossible.Clear();
            columnsPossible.Clear();

            if (activePiece != null)
            {
                columnsPossible.Add(activePiece.StartPositionX);

                rowsPossible.Add(activePiece.StartPositionY + 1);
                rowsPossible.Add(activePiece.StartPositionY + 2);
            }
        }

        private void MovePiece(int row, int column)
        {
            bool canMoveHere = rowsPossible.Contains(row) && columnsPossible.Contains(column);
            if (!canMoveHere) 
            {
                return;
            }

            activePiece.StartPositionX = column;
            activePiece.StartPositionY = row;
            activePiece = null;
            EvaluatePieceSpots();
        }
    }
}
