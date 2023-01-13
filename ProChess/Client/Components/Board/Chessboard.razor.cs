using Blazored.Modal;
using Blazored.Modal.Services;
using Client.Data;
using Client.Rules;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Shared.Data;

namespace Client.Components.Board
{
    public partial class Chessboard
    {
        [CascadingParameter]
        IModalService Modal { get; set; } = default!;
        Piece? activePiece = null;
        List<Cell> cellsPossible = new();

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
                cellsPossible = activePiece.EvaluateCells(WhitePieces, BlackPieces);
            }
        }

        private async Task MoveOrAttackPiece(Cell cell)
        {
            bool canMoveHere = cellsPossible.Where(x => x.Row == cell.Row && x.Column == cell.Column).Any();
            if (!canMoveHere)
            {
                return;
            }

            if (activePiece != null)
            {
                activePiece.MoveOrAttack(cell, activePiece.Color == PieceColor.White ? BlackPieces : WhitePieces);

                if (activePiece as Pawn != null && (activePiece.StartRow == _positionsTransformation[0] ||
                    activePiece.StartRow == _positionsTransformation[1]))
                {
                    var transformingPiece = new ModalParameters()
                        .Add(nameof(PawnTransformationPopUp.Piece), activePiece);
                    var modal = Modal.Show<PawnTransformationPopUp>("Choose a piece!", transformingPiece);
                    _ = await modal.Result;
                }

                activePiece = null;
                EvaluatePieceSpots();
            }
        }
    }
}
