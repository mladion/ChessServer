using Shared.Data;

namespace Shared.Rules
{
    public class Queen : Piece
    {
        private readonly int[] _edgeBoard = { 0, 7 };
        private readonly int[] _directionOffsets = { 1, -1 };

        public override List<Cell> GetMovementPossibilities(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cellsPossible = new();

            CheckTheMovesAhead(cellsPossible, whitePieces, blackPieces);
            CheckBackMoves(cellsPossible, whitePieces, blackPieces);
            CheckTheMovesOnTheRight(cellsPossible, whitePieces, blackPieces);
            CheckTheMovesOnTheLeft(cellsPossible, whitePieces, blackPieces);
            CheckTheMovesOnTheTopLeftDiagonal(cellsPossible, whitePieces, blackPieces);
            CheckTheMovesOnTheTopRightDiagonal(cellsPossible, whitePieces, blackPieces);
            CheckTheMovesOnTheBottomLeftDiagonal(cellsPossible, whitePieces, blackPieces);
            CheckTheMovesOnTheBottomRightDiagonal(cellsPossible, whitePieces, blackPieces);

            return cellsPossible;
        }

        private void CheckTheMovesAhead(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            Cell? cellPossible = null;

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
        }

        private void CheckBackMoves(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            Cell? cellPossible = null;

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
        }

        private void CheckTheMovesOnTheRight(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            Cell? cellPossible = null;

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
        }

        private void CheckTheMovesOnTheLeft(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            Cell? cellPossible = null;

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
        }

        private void CheckTheMovesOnTheTopLeftDiagonal(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
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

        private void CheckTheMovesOnTheTopRightDiagonal(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
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

        private void CheckTheMovesOnTheBottomLeftDiagonal(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
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

        private void CheckTheMovesOnTheBottomRightDiagonal(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
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
