using Shared.Data;

namespace Shared.Rules
{
    public class Queen : Piece
    {
        private readonly int[] _edgeBoard = { 0, 7 };
        private readonly int[] _directionOffsets = { 1, -1 };

        public Queen() { }

        public Queen(Piece piece)
        {
            StartRow = piece.StartRow;
            StartColumn = piece.StartColumn;
            Color = piece.Color;
            Image = piece.Image;
        }

        public override Piece Clone(Piece piece)
        {
            return new Queen(piece);
        }

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
            for (var row = this.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                Cell? cellPossible = EvaluateCellForMovement(row, this.StartColumn, whitePieces, blackPieces);
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
            for (var row = this.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                Cell? cellPossible = EvaluateCellForMovement(row, this.StartColumn, whitePieces, blackPieces);
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
            for (var column = this.StartColumn + _directionOffsets[1]; column >= _edgeBoard[0]; column--)
            {
                Cell? cellPossible = EvaluateCellForMovement(this.StartRow, column, whitePieces, blackPieces);
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
            for (var column = this.StartColumn + _directionOffsets[0]; column <= _edgeBoard[1]; column++)
            {
                Cell? cellPossible = EvaluateCellForMovement(this.StartRow, column, whitePieces, blackPieces);
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
            for (var row = this.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                if (column < _edgeBoard[0])
                    break;

                Cell? cellPossible = EvaluateCellForMovement(row, --column, whitePieces, blackPieces);
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
            for (var row = this.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                if (column > _edgeBoard[1])
                    break;

                Cell? cellPossible = EvaluateCellForMovement(row, ++column, whitePieces, blackPieces);
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
            for (var row = this.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                if (column < _edgeBoard[0])
                    break;

                Cell? cellPossible = EvaluateCellForMovement(row, --column, whitePieces, blackPieces);
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
            for (var row = this.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                if (column > _edgeBoard[1])
                    break;

                Cell? cellPossible = EvaluateCellForMovement(row, ++column, whitePieces, blackPieces);
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
