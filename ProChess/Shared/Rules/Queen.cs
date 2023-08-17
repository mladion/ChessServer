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

            cellsPossible.AddRange(CheckTheMovesAhead(whitePieces, blackPieces));
            cellsPossible.AddRange(CheckBackMoves(whitePieces, blackPieces));
            cellsPossible.AddRange(CheckTheMovesOnTheRight(whitePieces, blackPieces));
            cellsPossible.AddRange(CheckTheMovesOnTheLeft(whitePieces, blackPieces));
            cellsPossible.AddRange(CheckTheMovesOnTheTopLeftDiagonal(whitePieces, blackPieces));
            cellsPossible.AddRange(CheckTheMovesOnTheTopRightDiagonal(whitePieces, blackPieces));
            cellsPossible.AddRange(CheckTheMovesOnTheBottomLeftDiagonal(whitePieces, blackPieces));
            cellsPossible.AddRange(CheckTheMovesOnTheBottomRightDiagonal(whitePieces, blackPieces));

            return cellsPossible;
        }

        private List<Cell> CheckTheMovesAhead(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cells = new();

            for (var row = this.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                var cellPossible = EvaluateCellForMovement(row, this.StartColumn, whitePieces, blackPieces);

                if (cellPossible != null)
                {
                    cells.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                        break;
                }
                else
                    break;
            }

            return cells;
        }

        private List<Cell> CheckBackMoves(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List <Cell> cells = new();

            for (var row = this.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                var cellPossible = EvaluateCellForMovement(row, this.StartColumn, whitePieces, blackPieces);

                if (cellPossible != null)
                {
                    cells.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                        break;
                }
                else
                    break;
            }

            return cells;
        }

        private List<Cell> CheckTheMovesOnTheLeft(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cells = new();

            for (var column = this.StartColumn + _directionOffsets[1]; column >= _edgeBoard[0]; column--)
            {
                var cellPossible = EvaluateCellForMovement(this.StartRow, column, whitePieces, blackPieces);

                if (cellPossible != null)
                {
                    cells.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                        break;
                }
                else
                    break;
            }

            return cells;
        }

        private List<Cell> CheckTheMovesOnTheRight(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cells = new List<Cell> ();

            for (var column = this.StartColumn + _directionOffsets[0]; column <= _edgeBoard[1]; column++)
            {
                var cellPossible = EvaluateCellForMovement(this.StartRow, column, whitePieces, blackPieces);

                if (cellPossible != null)
                {
                    cells.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                        break;
                }
                else
                    break;
            }

            return cells;
        }

        private List<Cell> CheckTheMovesOnTheTopLeftDiagonal(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List <Cell> cells = new List<Cell> ();
            var column = this.StartColumn;

            for (var row = this.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                if (column < _edgeBoard[0])
                    break;

                Cell? cellPossible = EvaluateCellForMovement(row, --column, whitePieces, blackPieces);

                if (cellPossible != null)
                {
                    cells.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                        break;
                }
                else
                    break;
            }

            return cells;
        }

        private List<Cell> CheckTheMovesOnTheTopRightDiagonal(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List <Cell> cells = new List<Cell> ();
            var column = this.StartColumn;

            for (var row = this.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                if (column > _edgeBoard[1])
                    break;

                Cell? cellPossible = EvaluateCellForMovement(row, ++column, whitePieces, blackPieces);

                if (cellPossible != null)
                {
                    cells.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                        break;
                }
                else
                    break;
            }

            return cells;
        }

        private List<Cell> CheckTheMovesOnTheBottomLeftDiagonal(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cells = new List<Cell> ();
            var column = this.StartColumn;

            for (var row = this.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                if (column < _edgeBoard[0])
                    break;

                Cell? cellPossible = EvaluateCellForMovement(row, --column, whitePieces, blackPieces);

                if (cellPossible != null)
                {
                    cells.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                        break;
                }
                else
                    break;
            }

            return cells;
        }

        private List<Cell> CheckTheMovesOnTheBottomRightDiagonal(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cells = new List<Cell> ();
            var column = this.StartColumn;

            for (var row = this.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                if (column > _edgeBoard[1])
                    break;

                Cell? cellPossible = EvaluateCellForMovement(row, ++column, whitePieces, blackPieces);

                if (cellPossible != null)
                {
                    cells.Add(cellPossible);

                    if (cellPossible.ContainsPiece)
                        break;
                }
                else
                    break;
            }

            return cells;
        }
    }
}
