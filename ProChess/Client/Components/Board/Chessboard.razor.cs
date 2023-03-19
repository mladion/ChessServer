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
        [CascadingParameter]
        IModalService Modal { get; set; } = default!;

        //Some new variables for detection of check 
        bool itIsCheckforWhite = false;
        bool itIsCheckforBlack = false;
        //current position of Kings in game, need only for red backlight :)))
        int whiteKingRow = 0;
        int whiteKingColumn = 0;
        int blackKingRow = 0;
        int blackKingColumn = 0;

        InCheckPossibility IsCheckPossible = new InCheckPossibility();
        //Changes in main code to be discussed 

        Piece? activePiece = null;
        List<Cell> cellsPossible = new();

        private readonly string[] _horizontalAxis = { "a", "b", "c", "d", "e", "f", "g", "h" };
        private readonly string[] _verticalAxis = { "1", "2", "3", "4", "5", "6", "7", "8" };
        private readonly int[] _positionsTransformation = { 0, 7 };

        private List<Piece> _whitePieces { get; set; } = new List<Piece>();
        private List<Piece> _blackPieces { get; set; } = new List<Piece>();


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
                EvaluatePieceSpots();
            }
        }

        private void EvaluatePieceSpots()
        {
            cellsPossible.Clear();

            if (activePiece != null)
            {
                cellsPossible = activePiece.GetMovementPossibilities(_whitePieces, _blackPieces);


                // ---------------------------------------New Function Call-------------------------------------------
                // Do a verification of elements and delete from cellPossible moves which can do an instant Check&Mate
                // cellsPossible = IsCheckPossible.EvaluateListOfCellsPossibleForCheck(cellsPossible, _whitePieces, _blackPieces);
                // ---------------------------------------Position in code--------------------------------------------
            }

            // ----------------------------------New Function Call--------------------------------------
            // Do a verification of King's position and if there are detected a check, do it red
            KingPossitionEvaluate();
            // ----------------------------------Position in code---------------------------------------
        }

        private void KingPossitionEvaluate()
        {
            var BKingHere = _blackPieces.Where(x => x.GetType() == typeof(King)).FirstOrDefault();
            var kingBlack = new King();

            if (BKingHere != null)
                kingBlack = (King)BKingHere;

            var WKingHere = _whitePieces.Where(x => x.GetType() == typeof(King)).FirstOrDefault();
            var kingWhite = new King();

            if (WKingHere != null)
                kingWhite = (King)WKingHere;
            // save current position of king, because of problems with frontend part 
            whiteKingRow = kingWhite.StartRow;
            whiteKingColumn = kingWhite.StartColumn;
            blackKingRow = kingBlack.StartRow;
            blackKingColumn = kingBlack.StartColumn;
            
            // save in this flag if there are check
            itIsCheckforWhite = IsCheckPossible.EvaluateCellsForPossibleCheck(kingWhite, _whitePieces, _blackPieces);
            itIsCheckforBlack = IsCheckPossible.EvaluateCellsForPossibleCheck(kingBlack, _whitePieces, _blackPieces);
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
                EvaluatePieceSpots();
            }
        }
    }
}
