using Shared.Data;
using Shared.Helpers.Extensions;

namespace Shared.Rules
{
    public class Knight : Piece
    {
        private readonly int[] _directionOffsets = { 1, -1, 2, -2 };

        public override List<Cell> GetMovementPossibilities(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cellsPossible = new();

            CheckTheMovesAhead(cellsPossible, whitePieces, blackPieces);
            CheckBackMoves(cellsPossible, whitePieces, blackPieces);
            CheckTheMovesOnTheRight(cellsPossible, whitePieces, blackPieces);
            CheckTheMovesOnTheLeft(cellsPossible, whitePieces, blackPieces);

            return cellsPossible;
        }

        private void CheckTheMovesAhead(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[2], StartColumn + _directionOffsets[0], whitePieces, blackPieces);
            cellsPossible.AddNotNullableItem(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[2], StartColumn + _directionOffsets[1], whitePieces, blackPieces);
            cellsPossible.AddNotNullableItem(cellPossible);
        }

        private void CheckBackMoves(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[3], StartColumn + _directionOffsets[0], whitePieces, blackPieces);
            cellsPossible.AddNotNullableItem(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[3], StartColumn + _directionOffsets[1], whitePieces, blackPieces);
            cellsPossible.AddNotNullableItem(cellPossible);
        }

        private void CheckTheMovesOnTheRight(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[0], StartColumn + _directionOffsets[2], whitePieces, blackPieces);
            cellsPossible.AddNotNullableItem(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[1], StartColumn + _directionOffsets[2], whitePieces, blackPieces);
            cellsPossible.AddNotNullableItem(cellPossible);
        }

        private void CheckTheMovesOnTheLeft(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[0], StartColumn + _directionOffsets[3], whitePieces, blackPieces);
            cellsPossible.AddNotNullableItem(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[1], StartColumn + _directionOffsets[3], whitePieces, blackPieces);
            cellsPossible.AddNotNullableItem(cellPossible);
        }
        public override Piece Clone()
        {
            return new Knight
            {
                Color = Color,
                Image = Image,
                StartColumn = StartColumn,
                StartRow = StartRow
            };
        }
    }
}
