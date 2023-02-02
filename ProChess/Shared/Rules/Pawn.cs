using Shared.Data;
using Shared.Helpers.Extensions;

namespace Shared.Rules
{
    public class Pawn : Piece
    {
        private readonly int[] _startingPositions = { 1, 6 };
        private readonly int[] _directionOffsets = { 1, -1, 2, -2 };

        public override List<Cell> GetMovementPossibilities(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cellsPossible = new();

            CheckTheFrontMovement(cellsPossible, whitePieces, blackPieces);
            CheckTheSpecialFrontMovement(cellsPossible, whitePieces, blackPieces);
            CheckTheMovementsOfTheDiagonals(cellsPossible, whitePieces, blackPieces);

            return cellsPossible;
        }

        public override Cell? EvaluateCellForMovement(int row, int column, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var whitePiece = whitePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);
            var blackPiece = blackPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

            if (whitePiece == null && blackPiece == null)
            {
                return new Cell(row, column);
            }

            return null;
        }

        private void CheckTheFrontMovement(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            Cell? cellPossible = null;

            if (this.Color == PieceColor.White)
            {
                cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[0], this.StartColumn, whitePieces, blackPieces);
            }
            else
            {
                cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[1], this.StartColumn, whitePieces, blackPieces);
            }

            cellsPossible.AddCell(cellPossible);
        }

        private void CheckTheSpecialFrontMovement(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            Cell? cellPossible = null;

            if (cellsPossible.Any() && (this.StartRow == _startingPositions[0] || this.StartRow == _startingPositions[1]))
            {
                if (this.Color == PieceColor.White)
                {
                    cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[2], this.StartColumn, whitePieces, blackPieces);
                }
                else
                {
                    cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[3], this.StartColumn, whitePieces, blackPieces);
                }

                cellsPossible.AddCell(cellPossible);
            }
        }

        private void CheckTheMovementsOfTheDiagonals(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            Cell? cellPossible = null;

            if (this.Color == PieceColor.White)
            {
                cellPossible = EvaluateCellForAttack(this.StartRow + _directionOffsets[0], this.StartColumn + _directionOffsets[0], blackPieces);
                cellsPossible.AddCell(cellPossible);

                cellPossible = EvaluateCellForAttack(this.StartRow + _directionOffsets[0], this.StartColumn + _directionOffsets[1], blackPieces);
                cellsPossible.AddCell(cellPossible);
            }
            else
            {
                cellPossible = EvaluateCellForAttack(this.StartRow + _directionOffsets[1], this.StartColumn + _directionOffsets[0], whitePieces);
                cellsPossible.AddCell(cellPossible);

                cellPossible = EvaluateCellForAttack(this.StartRow + _directionOffsets[1], this.StartColumn + _directionOffsets[1], whitePieces);
                cellsPossible.AddCell(cellPossible);
            }
        }

        private Cell? EvaluateCellForAttack(int row, int column, List<Piece> pieces)
        {
            Piece? piece = pieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

            if (piece != null)
            {
                return new Cell(row, column, true);
            }

            return null;
        }
    }
}
