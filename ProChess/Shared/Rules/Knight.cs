using Shared.Data;

namespace Shared.Rules
{
    public class Knight : Piece
	{
        private readonly int[] _directionOffsets = { 1, -1, 2, -2 };
        public override List<Cell> GetMovementPossibilities(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            Cell? cellPossible = null;
            List<Cell> cellsPossible = new();

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[2], StartColumn + _directionOffsets[0], whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[2], StartColumn + _directionOffsets[1], whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[3], StartColumn + _directionOffsets[0], whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[3], StartColumn + _directionOffsets[1], whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[0], StartColumn + _directionOffsets[2], whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[1], StartColumn + _directionOffsets[2], whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[0], StartColumn + _directionOffsets[3], whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[1], StartColumn + _directionOffsets[3], whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            return cellsPossible;
        }
    }
}
