using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Shared.Data;
using Shared.Rules;

namespace Client.Components.Board
{
    public partial class Chessboard
    {
        #region Parameters

        [CascadingParameter] IModalService Modal { get; set; } = default!;

        #endregion

        #region Private filds and properties

        #region Fields

        private readonly int[] _positionsTransformation = { 0, 7 };
        private readonly string[] _horizontalAxis = { "a", "b", "c", "d", "e", "f", "g", "h" };
        private readonly string[] _verticalAxis = { "1", "2", "3", "4", "5", "6", "7", "8" };

        #endregion

        #region Property

        private bool _whiteTurn { get; set; } = true;
        private List<Piece> _whitePieces { get; set; } = new List<Piece>();
        private List<Piece> _blackPieces { get; set; } = new List<Piece>();

        #endregion

        #endregion

        Piece? activePiece = null;
        List<Cell> cellsPossible = new();

        protected override void OnInitialized()
        {
            GamePieces gamePieces = new GamePieces();

            _blackPieces = gamePieces.InitializationBlackPieces();
            _whitePieces = gamePieces.InitializationWhitePieces();
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

                if ((activePiece.Color == PieceColor.Black && _whiteTurn) || (activePiece.Color == PieceColor.White && !_whiteTurn))
                {
                    activePiece = null;
                    return;
                }

                EvaluatePieceSpots();
            }
        }

        private void EvaluatePieceSpots()
        {
            cellsPossible.Clear();

            if (activePiece != null)
            {
                cellsPossible = activePiece.GetMovementPossibilities(_whitePieces, _blackPieces);
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
                activePiece.MoveOrAttack(cell, _whitePieces, _blackPieces);

                if (activePiece as Pawn != null && (activePiece.StartRow == _positionsTransformation[0] ||
                    activePiece.StartRow == _positionsTransformation[1]))
                {
                    var transformingPiece = new ModalParameters()
                        .Add(nameof(PawnTransformationPopUp.Piece), activePiece);
                    var modal = Modal.Show<PawnTransformationPopUp>("Choose a piece!", transformingPiece);
                    var infoPiece = await modal.Result;
                    var newPiece = (infoPiece.Data as Piece) ?? throw new InvalidOperationException("Bad");

                    if (activePiece.Color == PieceColor.White)
                    {
                        _whitePieces.Remove(activePiece);
                        _whitePieces.Add(newPiece);
                    }
                    else
                    {
                        _blackPieces.Remove(activePiece);
                        _blackPieces.Add(newPiece);
                    }
                }

                activePiece = null;
                _whiteTurn = !_whiteTurn;
                EvaluatePieceSpots();
            }
        }
    }
}
