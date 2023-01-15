using System;
using Shared.Data;

namespace Shared.Rules
{
	public class Knight : Piece
	{
        public override List<Cell> EvaluateCells(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            Cell? cellPossible = null;
            List<Cell> cellsPossible = new();

            cellPossible = EvaluateCellForMovement(this.StartRow + 2, StartColumn + 1, whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + 2, StartColumn - 1, whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow - 2, StartColumn + 1, whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow - 2, StartColumn - 1, whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + 1, StartColumn + 2, whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow - 1, StartColumn + 2, whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow + 1, StartColumn - 2, whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForMovement(this.StartRow - 1, StartColumn - 2, whitePieces, blackPieces);
            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            return cellsPossible;
        }
    }
}
