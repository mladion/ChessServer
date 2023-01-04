using Client.Data;
using Client.Rules;

namespace Client.Components.Board
{
    public partial class Chessboard
    {
        Piece? activePiece = null;
        List<int> rowsPossible = new List<int>();
        List<int> columnsPossible = new List<int>();

        public readonly string[] HorizontalAxis = { "a", "b", "c", "d", "e", "f", "g", "h" };
        public readonly string[] VerticalAxis = { "1", "2", "3", "4", "5", "6", "7", "8" };

        public List<Piece> WhitePieces { get; set; } = new List<Piece>();
        public List<Piece> BlackPieces { get; set; } = new List<Piece>();

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
                    StartColumn = i,
                    StartLine = 1
                });

                BlackPieces.Add(new Piece
                {
                    Name = PieceType.Pawn,
                    Color = PieceColor.Black,
                    Direction = PieceDirection.Down,
                    Image = "/images/bP.svg",
                    StartColumn = i,
                    StartLine = 6
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
                            StartColumn = 0,
                            StartLine = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Rook,
                            Color = PieceColor.Black,
                            Direction = PieceDirection.All,
                            Image = "/images/bR.svg",
                            StartColumn = 7,
                            StartLine = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Knight,
                            Color = PieceColor.Black,
                            Direction = PieceDirection.All,
                            Image = "/images/bN.svg",
                            StartColumn = 1,
                            StartLine = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Knight,
                            Color = PieceColor.Black,
                            Direction = PieceDirection.All,
                            Image = "/images/bN.svg",
                            StartColumn = 6,
                            StartLine = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Bishop,
                            Color = PieceColor.Black,
                            Direction = PieceDirection.All,
                            Image = "/images/bB.svg",
                            StartColumn = 2,
                            StartLine = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Bishop,
                            Color = PieceColor.Black,
                            Direction = PieceDirection.All,
                            Image = "/images/bB.svg",
                            StartColumn = 5,
                            StartLine = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Queen,
                            Color = PieceColor.Black,
                            Direction = PieceDirection.All,
                            Image = "/images/bQ.svg",
                            StartColumn = 3,
                            StartLine = 7
                        },
                        new Piece
                        {
                            Name = PieceType.King,
                            Color = PieceColor.Black,
                            Direction = PieceDirection.All,
                            Image = "/images/bK.svg",
                            StartColumn = 4,
                            StartLine = 7
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
                            StartColumn = 0,
                            StartLine = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Rook,
                            Color = PieceColor.White,
                            Direction = PieceDirection.All,
                            Image = "/images/wR.svg",
                            StartColumn = 7,
                            StartLine = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Knight,
                            Color = PieceColor.White,
                            Direction = PieceDirection.All,
                            Image = "/images/wN.svg",
                            StartColumn = 1,
                            StartLine = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Knight,
                            Color = PieceColor.White,
                            Direction = PieceDirection.All,
                            Image = "/images/wN.svg",
                            StartColumn = 6,
                            StartLine = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Bishop,
                            Color = PieceColor.White,
                            Direction = PieceDirection.All,
                            Image = "/images/wB.svg",
                            StartColumn = 2,
                            StartLine = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Bishop,
                            Color = PieceColor.White,
                            Direction = PieceDirection.All,
                            Image = "/images/wB.svg",
                            StartColumn = 5,
                            StartLine = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Queen,
                            Color = PieceColor.White,
                            Direction = PieceDirection.All,
                            Image = "/images/wQ.svg",
                            StartColumn = 3,
                            StartLine = 0
                        },
                        new Piece
                        {
                            Name = PieceType.King,
                            Color = PieceColor.White,
                            Direction = PieceDirection.All,
                            Image = "/images/wK.svg",
                            StartColumn = 4,
                            StartLine = 0
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
                switch (activePiece.Name)
                {
                    case PieceType.Pawn:
                        rowsPossible = Pawn.EvaluateRowsSpots(activePiece);
                        columnsPossible = Pawn.EvaluateColumnsSpots(activePiece);
                        break;
                    case PieceType.Rook:
                        // code block
                        break;
                    case PieceType.Knight:
                        // code block
                        break;
                    case PieceType.Bishop:
                        // code block
                        break;
                    case PieceType.Queen:
                        // code block
                        break;
                    case PieceType.King:
                        // code block
                        break;
                }
            }
        }

        private void MovePiece(int row, int column)
        {
            bool canMoveHere = rowsPossible.Contains(row) && columnsPossible.Contains(column);
            if (!canMoveHere)
            {
                return;
            }

            if (activePiece != null)
            {
                switch (activePiece.Name)
                {
                    case PieceType.Pawn:
                        activePiece = Pawn.Move(activePiece, row, column);
                        break;
                    case PieceType.Rook:
                        // code block
                        break;
                    case PieceType.Knight:
                        // code block
                        break;
                    case PieceType.Bishop: 
                        // code block
                        break;
                    case PieceType.Queen: 
                        // code block
                        break;
                    case PieceType.King:
                        // code block
                        break;
                }
                activePiece = null;
                EvaluatePieceSpots();
            }
        }
    }
}
