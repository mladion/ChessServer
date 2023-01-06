using Client.Data;
using Client.Rules;
using Microsoft.AspNetCore.Components.Web;

namespace Client.Components.Board
{
    public partial class Chessboard
    {
        Piece? activePiece = null;
        List<(int row, int column)> cellsPossible = new();

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
                    Image = "/images/wP.svg",
                    StartColumn = i,
                    StartRow = 1
                });

                BlackPieces.Add(new Piece
                {
                    Name = PieceType.Pawn,
                    Color = PieceColor.Black,
                    Image = "/images/bP.svg",
                    StartColumn = i,
                    StartRow = 6
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
                            Image = "/images/bR.svg",
                            StartColumn = 0,
                            StartRow = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Rook,
                            Color = PieceColor.Black,
                            Image = "/images/bR.svg",
                            StartColumn = 7,
                            StartRow = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Knight,
                            Color = PieceColor.Black,
                            Image = "/images/bN.svg",
                            StartColumn = 1,
                            StartRow = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Knight,
                            Color = PieceColor.Black,
                            Image = "/images/bN.svg",
                            StartColumn = 6,
                            StartRow = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Bishop,
                            Color = PieceColor.Black,
                            Image = "/images/bB.svg",
                            StartColumn = 2,
                            StartRow = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Bishop,
                            Color = PieceColor.Black,
                            Image = "/images/bB.svg",
                            StartColumn = 5,
                            StartRow = 7
                        },
                        new Piece
                        {
                            Name = PieceType.Queen,
                            Color = PieceColor.Black,
                            Image = "/images/bQ.svg",
                            StartColumn = 3,
                            StartRow = 7
                        },
                        new Piece
                        {
                            Name = PieceType.King,
                            Color = PieceColor.Black,
                            Image = "/images/bK.svg",
                            StartColumn = 4,
                            StartRow = 7
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
                            Image = "/images/wR.svg",
                            StartColumn = 0,
                            StartRow = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Rook,
                            Color = PieceColor.White,
                            Image = "/images/wR.svg",
                            StartColumn = 7,
                            StartRow = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Knight,
                            Color = PieceColor.White,
                            Image = "/images/wN.svg",
                            StartColumn = 1,
                            StartRow = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Knight,
                            Color = PieceColor.White,
                            Image = "/images/wN.svg",
                            StartColumn = 6,
                            StartRow = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Bishop,
                            Color = PieceColor.White,
                            Image = "/images/wB.svg",
                            StartColumn = 2,
                            StartRow = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Bishop,
                            Color = PieceColor.White,
                            Image = "/images/wB.svg",
                            StartColumn = 5,
                            StartRow = 0
                        },
                        new Piece
                        {
                            Name = PieceType.Queen,
                            Color = PieceColor.White,
                            Image = "/images/wQ.svg",
                            StartColumn = 3,
                            StartRow = 0
                        },
                        new Piece
                        {
                            Name = PieceType.King,
                            Color = PieceColor.White,
                            Image = "/images/wK.svg",
                            StartColumn = 4,
                            StartRow = 0
                        }
                    });
                }
            }
        }

        private void ClickOnPiece(MouseEventArgs e, Piece piece)
        {
            if (activePiece == piece)
            {
                activePiece = null;
                EvaluatePieceSpots();

                return;
            }

            if (activePiece == null) 
            { 
                activePiece = piece; 
                EvaluatePieceSpots(); 
            }
        }

        private void EvaluatePieceSpots()
        {
            cellsPossible.Clear();

            if (activePiece != null)
            {
                switch (activePiece.Name)
                {
                    case PieceType.Pawn:
                        cellsPossible = Pawn.EvaluateCells(activePiece, WhitePieces, BlackPieces);
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

        private void MoveOrAttackPiece(int row, int column)
        {
            bool canMoveHere = cellsPossible.Contains((row, column));
            if (!canMoveHere)
            {
                return;
            }

            if (activePiece != null)
            {
                switch (activePiece.Name)
                {
                    case PieceType.Pawn:
                        activePiece = Pawn.MoveOrAttack(activePiece, row, column, 
                            activePiece.Color  == PieceColor.White ? BlackPieces : WhitePieces);
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
