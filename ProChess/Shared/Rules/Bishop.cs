using System;
using Shared.Data;

namespace Shared.Rules
{
    public class Bishop : Piece
    {
        private readonly int[] _edgeBoard = { 0, 7 };

        public override List<Cell> EvaluateCells(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var column = this.StartColumn;
            Cell? cellPossible = null;
            var cellsPossible = new List<Cell>();

            // checking the possibilities in the upper left
            for (var row = this.StartRow + 1; row <= _edgeBoard[1]; row++)
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

            // checking the possibilities in the upper right
            for (var row = this.StartRow + 1; row <= _edgeBoard[1]; row++)
            {
                if (row == this.StartRow + 1)
                    column = this.StartColumn;

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

            // checking the possibilities in the lower left
            for (var row = this.StartRow - 1; row >= _edgeBoard[0]; row--)
            {
                if (row == this.StartRow - 1)
                    column = this.StartColumn;

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

            // checking the possibilities in the lower right
            for (var row = this.StartRow - 1; row >= _edgeBoard[0]; row--)
            {
                if (row == this.StartRow - 1)
                    column = this.StartColumn;

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

            return cellsPossible;
        }
    }
}
