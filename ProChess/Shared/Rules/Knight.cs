using Shared.Data;
using Shared.Helpers.Extensions;

namespace Shared.Rules
{
    public class Knight : Piece
    {
        private readonly int[] _directionOffsets = { 1, -1, 2, -2 };

        public Knight() { }

        public Knight(Piece piece)
        {
            StartRow = piece.StartRow;
            StartColumn = piece.StartColumn;
            Color = piece.Color;
            Image = piece.Image;
        }

        public override Piece Clone(Piece piece)
        {
            return new Knight(piece);
        }

        public override List<Cell> GetMovementPossibilities(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cellsPossible = new();

            cellsPossible.AddRange(CheckTheMovesAhead(whitePieces, blackPieces));
            cellsPossible.AddRange(CheckBackMoves(whitePieces, blackPieces));
            cellsPossible.AddRange(CheckTheMovesOnTheRight(whitePieces, blackPieces));
            cellsPossible.AddRange(CheckTheMovesOnTheLeft(whitePieces, blackPieces));

            return cellsPossible;
        }

        private List<Cell> CheckTheMovesAhead(List<Piece> whitePieces, List<Piece> blackPieces)
        {   
            var cells = new List<Cell>();

            cells.AddNotNullableItem(EvaluateCellForMovement(this.StartRow + _directionOffsets[2], StartColumn + _directionOffsets[0], whitePieces, blackPieces));
            cells.AddNotNullableItem(EvaluateCellForMovement(this.StartRow + _directionOffsets[2], StartColumn + _directionOffsets[1], whitePieces, blackPieces));

            return cells;
        }

        private List<Cell> CheckBackMoves(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cells = new List<Cell>();
            
            cells.AddNotNullableItem(EvaluateCellForMovement(this.StartRow + _directionOffsets[3], StartColumn + _directionOffsets[0], whitePieces, blackPieces));
            cells.AddNotNullableItem(EvaluateCellForMovement(this.StartRow + _directionOffsets[3], StartColumn + _directionOffsets[1], whitePieces, blackPieces));

            return cells;
        }

        private List<Cell> CheckTheMovesOnTheRight(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cells = new List<Cell>();
            
            cells.AddNotNullableItem(EvaluateCellForMovement(this.StartRow + _directionOffsets[0], StartColumn + _directionOffsets[2], whitePieces, blackPieces));
            cells.AddNotNullableItem(EvaluateCellForMovement(this.StartRow + _directionOffsets[1], StartColumn + _directionOffsets[2], whitePieces, blackPieces));
            
            return cells;
        }

        private List<Cell> CheckTheMovesOnTheLeft(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cells = new List<Cell>();

            cells.AddNotNullableItem(EvaluateCellForMovement(this.StartRow + _directionOffsets[0], StartColumn + _directionOffsets[3], whitePieces, blackPieces));
            cells.AddNotNullableItem(EvaluateCellForMovement(this.StartRow + _directionOffsets[1], StartColumn + _directionOffsets[3], whitePieces, blackPieces));

            return cells;
        }
    }
}
