using Shared.Data;

namespace Shared.Rules
{
    public class Pawn : Piece
    {
        private readonly int[] _startingPositions = { 1, 6 };
        private readonly int[] _directionOffsets = { 1, -1, 2, -2 };

        public override List<Cell> EvaluateCells(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            Cell? cellPossible = null;
            List<Cell> cellsPossible = new();

            cellPossible = EvaluateCellForMovement(this.Color == PieceColor.White ? this.StartRow + _directionOffsets[0] :
                this.StartRow + _directionOffsets[1], this.StartColumn, whitePieces, blackPieces);

            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            if (cellsPossible.Any() && (this.StartRow == _startingPositions[0] || this.StartRow == _startingPositions[1]))
            {
                cellPossible = EvaluateCellForMovement(this.Color == PieceColor.White ? this.StartRow + _directionOffsets[2] :
                    this.StartRow + _directionOffsets[3], this.StartColumn, whitePieces, blackPieces);

                if (cellPossible != null)
                    cellsPossible.Add(cellPossible);
            }

            cellPossible = EvaluateCellForAttack(this.Color == PieceColor.White ? this.StartRow + _directionOffsets[0] :
                this.StartRow + _directionOffsets[1], this.StartColumn + _directionOffsets[0],
                this.Color == PieceColor.White ? blackPieces : whitePieces);

            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForAttack(this.Color == PieceColor.White ? this.StartRow + _directionOffsets[0] :
                this.StartRow + _directionOffsets[1], this.StartColumn + _directionOffsets[1],
                this.Color == PieceColor.White ? blackPieces : whitePieces);

            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            return cellsPossible;
        }

        public Cell? EvaluateCellForAttack(int row, int column, List<Piece> pieces)
        {
            Piece? piece = pieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

            if (piece != null)
            {
                return new Cell(row, column);
            }

            return null;
        }
    }
}
