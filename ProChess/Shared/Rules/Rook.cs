using Shared.Data;
using System.Reflection.Metadata.Ecma335;

namespace Shared.Rules
{
    public class Rook : Piece
    {
        public bool IsMoved { get; set; }

        private readonly int[] _edgeBoard = { 0, 7 };
        private readonly int[] _directionOffsets = { 1, -1};

        public override List<Cell> GetMovementPossibilities(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cellsPossible = new();

            cellsPossible.AddRange(CheckTheMovesAhead(whitePieces, blackPieces));
            cellsPossible.AddRange(CheckBackMoves(whitePieces, blackPieces));
            cellsPossible.AddRange(CheckTheMovesOnTheRight(whitePieces, blackPieces));
            cellsPossible.AddRange(CheckTheMovesOnTheLeft(whitePieces, blackPieces));

            return cellsPossible;
        }

        public override void MoveOrAttack(Cell cell, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            this.IsMoved = true;
            base.MoveOrAttack(cell, whitePieces, blackPieces);
        }

        private List<Cell> CheckTheMovesAhead(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cells = new List<Cell>();

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
            List<Cell> cells = new List<Cell>();

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
        
        private List<Cell> CheckTheMovesOnTheRight(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cells = new List<Cell>();

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
        
        private List<Cell> CheckTheMovesOnTheLeft(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cells = new List<Cell> ();

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

        
    }
}
