using Blazored.Modal;
using Client.Data;
using Microsoft.AspNetCore.Components;

namespace Client.Components.Board
{
    public partial class PawnTransformationPopUp
    {
        [Parameter]
        public Piece? Piece { get; set; } =  null;
        [CascadingParameter] 
        BlazoredModalInstance BlazoredModal { get; set; } = default!;
        private List<Piece> Pieces { get; set; } = new List<Piece>();

        //protected override void OnInitialized()
        //{
        //    var color = Piece.Color == PieceColor.White ? "w" : "b";
        //    Pieces.AddRange(new List<Piece>
        //    {
        //        new Piece
        //        {
        //            Name = PieceType.Queen,
        //            Image = $"/images/{color}Q.svg"
        //        },
        //        new Piece
        //        {
        //            Name = PieceType.Rook,
        //            Image = $"/images/{color}R.svg"
        //        },
        //        new Piece
        //        {
        //            Name = PieceType.Bishop,
        //            Image = $"/images/{color}B.svg"
        //        },
        //        new Piece
        //        {
        //            Name = PieceType.Knight,
        //            Image = $"/images/{color}N.svg"
        //        }
        //    });
        //}

        //private async Task TransformPiece(Piece piece)
        //{
        //    Piece.Name = piece.Name;
        //    Piece.Image = piece.Image;

        //    await BlazoredModal.CloseAsync();
        //}
    }
}
