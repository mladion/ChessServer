using Blazored.Modal;
using Blazored.Modal.Services;
using Client.Data;
using Client.Rules;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Client.Components.Board
{
    public partial class Chessboard
    {
        [CascadingParameter] 
        IModalService Modal { get; set; } = default!;
        Piece? activePiece = null;
        List<(int row, int column)> cellsPossible = new();

        private readonly string[] HorizontalAxis = { "a", "b", "c", "d", "e", "f", "g", "h" };
        private readonly string[] VerticalAxis = { "1", "2", "3", "4", "5", "6", "7", "8" };
        private readonly int[] _positionsTransformation = { 0, 7 };

        public List<Piece> WhitePieces { get; set; } = new List<Piece>();
        public List<Piece> BlackPieces { get; set; } = new List<Piece>();

        protected override void OnInitialized()
        {
            GamePieces gamePieces = new GamePieces();

            BlackPieces = gamePieces.InitializationBlackPieces();
            WhitePieces = gamePieces.InitializationWhitePieces();
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

        private async Task MoveOrAttackPiece(int row, int column)
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
                        Pawn.MoveOrAttack(activePiece, row, column,
                            activePiece.Color == PieceColor.White ? BlackPieces : WhitePieces);

                        if (activePiece.StartRow == _positionsTransformation[0] ||
                            activePiece.StartRow == _positionsTransformation[1])
                        {
                            var transformingPiece = new ModalParameters()
                                .Add(nameof(PawnTransformationPopUp.Piece), activePiece);
                            var modal = Modal.Show<PawnTransformationPopUp>("Choose a piece!", transformingPiece);
                            _ = await modal.Result;
                        }

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
