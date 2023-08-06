using Shared.Data;
using Shared.Helpers.Extensions;

namespace Shared.Rules
{
    public class Pawn : Piece
    {
        private readonly int[] _startingPositions = { 1, 6 };
        private readonly int[] _directionOffsets = { 1, -1, 2, -2 };

        public Pawn() { }

        public Pawn(Piece piece)
        {
            StartRow = piece.StartRow;
            StartColumn = piece.StartColumn;
            Color = piece.Color;
            Image = piece.Image;
        }

        public override Piece Clone(Piece piece)
        {
            return new Pawn(piece);
        }

        public override List<Cell> GetMovementPossibilities(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cellsPossible = new();

            CheckTheFrontMove(cellsPossible, whitePieces, blackPieces);
            CheckTheSpecialFrontMove(cellsPossible, whitePieces, blackPieces);
            CheckTheMovesOfTheDiagonals(cellsPossible, whitePieces, blackPieces);

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

        private void CheckTheFrontMove(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            Cell? cellPossible;
            if (this.Color == PieceColor.White)
            {
                cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[0], this.StartColumn, whitePieces, blackPieces);
            }
            else
            {
                cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[1], this.StartColumn, whitePieces, blackPieces);
            }

            cellsPossible.AddNotNullableItem(cellPossible);
        }

        private void CheckTheSpecialFrontMove(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            if (cellsPossible.Any() && (this.StartRow == _startingPositions[0] || this.StartRow == _startingPositions[1]))
            {
                Cell? cellPossible;
                if (this.Color == PieceColor.White)
                {
                    cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[2], this.StartColumn, whitePieces, blackPieces);
                }
                else
                {
                    cellPossible = EvaluateCellForMovement(this.StartRow + _directionOffsets[3], this.StartColumn, whitePieces, blackPieces);
                }

                cellsPossible.AddNotNullableItem(cellPossible);
            }
        }

        private void CheckTheMovesOfTheDiagonals(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            Cell? cellPossible;
            if (this.Color == PieceColor.White)
            {
                cellPossible = EvaluateCellForAttack(this.StartRow + _directionOffsets[0], this.StartColumn + _directionOffsets[0], blackPieces);
                cellsPossible.AddNotNullableItem(cellPossible);

                cellPossible = EvaluateCellForAttack(this.StartRow + _directionOffsets[0], this.StartColumn + _directionOffsets[1], blackPieces);
                cellsPossible.AddNotNullableItem(cellPossible);
            }
            else
            {
                cellPossible = EvaluateCellForAttack(this.StartRow + _directionOffsets[1], this.StartColumn + _directionOffsets[0], whitePieces);
                cellsPossible.AddNotNullableItem(cellPossible);

                cellPossible = EvaluateCellForAttack(this.StartRow + _directionOffsets[1], this.StartColumn + _directionOffsets[1], whitePieces);
                cellsPossible.AddNotNullableItem(cellPossible);
            }
        }

        private static Cell? EvaluateCellForAttack(int row, int column, List<Piece> pieces)
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
