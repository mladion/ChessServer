using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Shared.Data;
using Shared.Rules;

namespace Client.Components.Board
{
    public partial class PawnTransformationPopUp
    {
        [Parameter]
        public Piece? Piece { get; set; } = null;

        [CascadingParameter]
        BlazoredModalInstance BlazoredModal { get; set; } = default!;

        private List<Piece> Pieces { get; set; } = new List<Piece>();

        protected override void OnInitialized()
        {
            if (Piece != null)
            {
                var color = Piece.Color == PieceColor.White ? "w" : "b";
                Pieces.AddRange(new List<Piece>
                {
                    new Queen
                    {
                        Color = Piece.Color,
                        Image = $"/images/{color}Q.svg",
                        StartColumn = Piece.StartColumn,
                        StartRow = Piece.StartRow
                    },
                    new Rook
                    {
                        Color = Piece.Color,
                        Image = $"/images/{color}R.svg",
                        StartColumn = Piece.StartColumn,
                        StartRow = Piece.StartRow,
                        IsMoved = true
                    },
                    new Bishop
                    {
                        Color = Piece.Color,
                        Image = $"/images/{color}B.svg",
                        StartColumn = Piece.StartColumn,
                        StartRow = Piece.StartRow
                    },
                    new Knight
                    {
                        Color = Piece.Color,
                        Image = $"/images/{color}N.svg",
                        StartColumn = Piece.StartColumn,
                        StartRow = Piece.StartRow
                    }
                });
            }
        }

        private async Task TransformPiece(Piece piece)
        {
            await BlazoredModal.CloseAsync(ModalResult.Ok(piece));
        }
    }
}
