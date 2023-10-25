using Shared.Data;
using System.Net.Http.Headers;

namespace Shared.Rules
{
    public class Bishop : Piece
    {
        private readonly int[] _edgeBoard = { 0, 7 };
        private readonly int[] _directionOffsets = { 1, -1 };

        public Bishop() { }

        public Bishop(Piece piece)
        {
            StartRow = piece.StartRow;
            StartColumn = piece.StartColumn;
            Color = piece.Color;
            Image = piece.Image;
        }

        public override Piece Clone(Piece piece)
        {
            return new Bishop(piece);
        }

        public override List<Cell> GetMovementPossibilities(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cellsPossible = new();

            cellsPossible.AddRange(CheckTheMovesOnTheTopLeftDiagonal(whitePieces, blackPieces));
            cellsPossible.AddRange(CheckTheMovesOnTheTopRightDiagonal(whitePieces, blackPieces));
            cellsPossible.AddRange(CheckTheMovesOnTheBottomLeftDiagonal(whitePieces, blackPieces));
            cellsPossible.AddRange(CheckTheMovesOnTheBottomRightDiagonal(whitePieces, blackPieces));

            return cellsPossible;
        }

        private List<Cell> CheckTheMovesOnTheTopLeftDiagonal(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cells = new List<Cell>();
            var column = this.StartColumn;

            for (var row = this.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                if (column < _edgeBoard[0])
                    break;

                var cellPossible = EvaluateCellForMovement(row, --column, whitePieces, blackPieces);

                if (cellPossible != null)
                {
                    cells.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                    {
                        return cells;
                    }
                }
                else
                    break;
            }
            return cells;
        }

        private List<Cell> CheckTheMovesOnTheTopRightDiagonal(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cells = new List<Cell>();
            var column = this.StartColumn;

            for (var row = this.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                if (column > _edgeBoard[1])
                    break;

                var cellPossible = EvaluateCellForMovement(row, ++column, whitePieces, blackPieces);

                if (cellPossible != null)
                {
                    cells.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                    {
                        return cells;
                    }
                }
                else
                    break;
            }
            return cells;
        }

        private List<Cell> CheckTheMovesOnTheBottomLeftDiagonal(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cells = new List<Cell>();
            var column = this.StartColumn;

            for (var row = this.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                if (column < _edgeBoard[0])
                    break;

                var cellPossible = EvaluateCellForMovement(row, --column, whitePieces, blackPieces);

                if (cellPossible != null)
                {
                    cells.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                    {
                        return cells;
                    }
                }
                else
                    break;
            }
            return cells;
        }

        private List<Cell> CheckTheMovesOnTheBottomRightDiagonal(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cells = new List<Cell>();
            var column = this.StartColumn;

            for (var row = this.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                if (column > _edgeBoard[1])
                    break;

                var cellPossible = EvaluateCellForMovement(row, ++column, whitePieces, blackPieces);

                if (cellPossible != null)
                {
                    cells.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                    {
                        return cells;
                    }
                }
                else
                    break;
            }
            return cells;
        }
    }
}
