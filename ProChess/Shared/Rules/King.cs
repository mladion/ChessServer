using Shared.Data;

namespace Shared.Rules
{
    public class King : Piece
    {
        private readonly int[] _directionOffsets = { 1, -1 };
        public override List<Cell> EvaluateCells(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            Cell? cellPossible = null;
            List<Cell> cellsPossible = new();

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[0], this.StartColumn, whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[1], this.StartColumn, whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow, this.StartColumn + _directionOffsets[1], whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow, this.StartColumn + _directionOffsets[0], whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[0], this.StartColumn + _directionOffsets[1], whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[0], this.StartColumn + _directionOffsets[0], whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[1], this.StartColumn + _directionOffsets[1], whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[1], this.StartColumn + _directionOffsets[0], whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);


            return cellsPossible;
        }
    }
}

