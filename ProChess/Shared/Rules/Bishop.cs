using System.Data.Common;
using Shared.Data;
using Shared.Helpers.Extensions;

namespace Shared.Rules
{
    public class Bishop : Piece
    {
        private readonly int[] _edgeBoard = { 0, 7 };
        private readonly int[] _directionOffsets = { 1, -1};

        public override List<Cell> GetMovementPossibilities(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cellsPossible = new();

            CheckOutTheMovesOnTheTopLeft(cellsPossible, whitePieces, blackPieces);
            CheckOutTheMovesOnTheTopRight(cellsPossible, whitePieces, blackPieces);
            CheckOutTheMovesOnTheBottomLeft(cellsPossible, whitePieces, blackPieces);
            CheckOutTheMovesOnTheBottomRight(cellsPossible, whitePieces, blackPieces);

            return cellsPossible;
        }

        private void CheckOutTheMovesOnTheTopLeft(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var column = this.StartColumn;
            Cell? cellPossible = null;

            for (var row = this.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                if (column < _edgeBoard[0])
                    break;

                cellPossible = EvaluateCellForMovement(row, --column, whitePieces, blackPieces);
                if (cellPossible != null)
                {
                    cellsPossible.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                        break;
                }
                else
                    break;
            }
        }

        private void CheckOutTheMovesOnTheTopRight(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var column = this.StartColumn;
            Cell? cellPossible = null;

            for (var row = this.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                if (column > _edgeBoard[1])
                    break;

                cellPossible = EvaluateCellForMovement(row, ++column, whitePieces, blackPieces);
                if (cellPossible != null)
                {
                    cellsPossible.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                        break;
                }
                else
                    break;
            }
        }

        private void CheckOutTheMovesOnTheBottomLeft(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var column = this.StartColumn;
            Cell? cellPossible = null;

            for (var row = this.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                if (column < _edgeBoard[0])
                    break;

                cellPossible = EvaluateCellForMovement(row, --column, whitePieces, blackPieces);
                if (cellPossible != null)
                {
                    cellsPossible.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                        break;
                }
                else
                    break;
            }
        }

        private void CheckOutTheMovesOnTheBottomRight(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var column = this.StartColumn;
            Cell? cellPossible = null;

            for (var row = this.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                if (column > _edgeBoard[1])
                    break;

                cellPossible = EvaluateCellForMovement(row, ++column, whitePieces, blackPieces);
                if (cellPossible != null)
                {
                    cellsPossible.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                        break;
                }
                else
                    break;
            }
        }
    }
}
