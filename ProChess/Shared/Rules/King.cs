using Shared.Data;
using Shared.Helpers.Extensions;

namespace Shared.Rules
{
    public class King : Piece
    {
        private readonly int[] _directionOffsets = { 1, -1 };

        public override List<Cell> GetMovementPossibilities(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cellsPossible = new();

            CheckTheMoveAhead(cellsPossible, whitePieces, blackPieces);
            CheckBackMove(cellsPossible, whitePieces, blackPieces);
            CheckTheMoveOnTheLeft(cellsPossible, whitePieces, blackPieces);
            CheckTheMoveOnTheRight(cellsPossible, whitePieces, blackPieces);
            CheckTheMoveOnTheTopLeftDiagonal(cellsPossible, whitePieces, blackPieces);
            CheckTheMoveOnTheTopRightDiagonal(cellsPossible, whitePieces, blackPieces);
            CheckTheMoveOnTheBottomLeftDiagonal(cellsPossible, whitePieces, blackPieces);
            CheckTheMoveOnTheBottomRightDiagonal(cellsPossible, whitePieces, blackPieces);

            return cellsPossible;
        }

        private void CheckTheMoveAhead(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[0], this.StartColumn, whitePieces, blackPieces);
            cellsPossible.AddNotNullableItem(cellPossible);
        }

        private void CheckBackMove(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[1], this.StartColumn, whitePieces, blackPieces);
            cellsPossible.AddNotNullableItem(cellPossible);
        }

        private void CheckTheMoveOnTheLeft(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cellPossible = EvaluateCellForMovement(this.StartRow, this.StartColumn + _directionOffsets[1], whitePieces, blackPieces);
            cellsPossible.AddNotNullableItem(cellPossible);
        }

        private void CheckTheMoveOnTheRight(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cellPossible = EvaluateCellForMovement(this.StartRow, this.StartColumn + _directionOffsets[0], whitePieces, blackPieces);
            cellsPossible.AddNotNullableItem(cellPossible);
        }

        private void CheckTheMoveOnTheTopLeftDiagonal(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[0], this.StartColumn + _directionOffsets[1], whitePieces, blackPieces);
            cellsPossible.AddNotNullableItem(cellPossible);
        }

        private void CheckTheMoveOnTheTopRightDiagonal(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[0], this.StartColumn + _directionOffsets[0], whitePieces, blackPieces);
            cellsPossible.AddNotNullableItem(cellPossible);
        }

        private void CheckTheMoveOnTheBottomLeftDiagonal(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[1], this.StartColumn + _directionOffsets[1], whitePieces, blackPieces);
            cellsPossible.AddNotNullableItem(cellPossible);
        }

        private void CheckTheMoveOnTheBottomRightDiagonal(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[1], this.StartColumn + _directionOffsets[0], whitePieces, blackPieces);
            cellsPossible.AddNotNullableItem(cellPossible);
        }
    }
}

