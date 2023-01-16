using Shared.Data;

namespace Shared.Rules
{
    public class Queen : Piece
    {
        private readonly int[] _edgeBoard = { 0, 7 };
        private readonly int[] _directionOffsets = { 1, -1 };

        public override List<Cell> EvaluateCells(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cellsPossible = new();

            cellsPossible.AddRange(EvaluateCellForRowAndColumnMovement(whitePieces, blackPieces));
            cellsPossible.AddRange(EvaluateCellForDiagonalMovement(whitePieces, blackPieces));
            
            return cellsPossible;
        }

        private List<Cell> EvaluateCellForRowAndColumnMovement(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            Cell? cellPossible = null;
            List<Cell> cellsPossible = new();

            // checking the possibilities in the upper
            for (var row = this.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                cellPossible = EvaluateCellForMovement(row, this.StartColumn, whitePieces, blackPieces);
                if (cellPossible != null)
                {
                    cellsPossible.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                        break;
                }
                else
                    break;
            }

            // checking the possibilities in the lower
            for (var row = this.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                cellPossible = EvaluateCellForMovement(row, this.StartColumn, whitePieces, blackPieces);
                if (cellPossible != null)
                {
                    cellsPossible.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                        break;
                }
                else
                    break;
            }

            // checking the possibilities in the right
            for (var column = this.StartColumn + _directionOffsets[0]; column <= _edgeBoard[1]; column++)
            {
                cellPossible = EvaluateCellForMovement(this.StartRow, column, whitePieces, blackPieces);
                if (cellPossible != null)
                {
                    cellsPossible.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                        break;
                }
                else
                    break;
            }

            // checking the possibilities in the left
            for (var column = this.StartColumn + _directionOffsets[1]; column >= _edgeBoard[0]; column--)
            {
                cellPossible = EvaluateCellForMovement(this.StartRow, column, whitePieces, blackPieces);
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

        private List<Cell> EvaluateCellForDiagonalMovement(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            int column = this.StartColumn;
            Cell? cellPossible = null;
            List<Cell> cellsPossible = new();

            // checking the possibilities in the upper left
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

            // checking the possibilities in the upper right
            for (var row = this.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
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
            for (var row = this.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                if (row == this.StartRow + _directionOffsets[1])
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
            for (var row = this.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                if (row == this.StartRow + _directionOffsets[1])
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
