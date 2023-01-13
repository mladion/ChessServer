using Client.Data;
using Shared.Data;

namespace Client.Rules
{
    public class Pawn : Piece
    {
        private readonly int[] _startingPositions = { 1, 6 };

        public override List<Cell> EvaluateCells(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cellsPossible = new List<Cell>();
            Cell? cellPossible = null;

            cellPossible = EvaluateCellForMovement(this.Color == PieceColor.White ? this.StartRow + 1 : this.StartRow - 1, this.StartColumn, whitePieces, blackPieces);

            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            if (cellsPossible.Any() && (this.StartRow == _startingPositions[0] || this.StartRow == _startingPositions[1]))
            {
                cellPossible = EvaluateCellForMovement(this.Color == PieceColor.White ? this.StartRow + 2 : this.StartRow - 2, this.StartColumn, whitePieces, blackPieces);

                if (cellPossible != null)
                    cellsPossible.Add(cellPossible);
            }

            cellPossible = EvaluateCellForAttack(this.Color == PieceColor.White ? this.StartRow + 1 : this.StartRow - 1, this.StartColumn + 1,
                this.Color == PieceColor.White ? blackPieces : whitePieces);

            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            cellPossible = EvaluateCellForAttack(this.Color == PieceColor.White ? this.StartRow + 1 : this.StartRow - 1, this.StartColumn - 1,
                this.Color == PieceColor.White ? blackPieces : whitePieces);

            if (cellPossible != null)
                cellsPossible.Add(cellPossible);

            return cellsPossible;
        }

        private Cell? EvaluateCellForMovement(int row, int column, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var whitePiece = whitePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

            var blackPiece = blackPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

            if (whitePiece == null && blackPiece == null)
            {
                return new Cell(row, column);
            }

            return null;
        }
    }
}
