﻿namespace Shared.Data
{
    public abstract class Piece
    {
        public PieceColor Color { get; set; }
        public int StartRow { get; set; }
        public int StartColumn { get; set; }
        public string Image { get; set; } = "";

        private readonly int[] _edgeBoard = { 0, 7 };

        public abstract List<Cell> GetMovementPossibilities(List<Piece> whitePieces, List<Piece> blackPieces);

        public virtual Cell? EvaluateCellForMovement(int row, int column, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            if (row >= _edgeBoard[0] && column >= _edgeBoard[0] && row <= _edgeBoard[1] && column <= _edgeBoard[1])
            {
                var whitePiece = whitePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);
                var blackPiece = blackPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

                if (whitePiece == null && blackPiece == null)
                {
                    return new Cell(row, column);
                }
                else if ((this.Color == PieceColor.Black && whitePiece != null) ||
                    (this.Color == PieceColor.White && blackPiece != null))
                {
                    return new Cell(row, column, true);
                }
            }

            return null;
        }

        public virtual void MoveOrAttack(Cell cell, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var pieces = new List<Piece>();

            if (this.Color == PieceColor.White)
                pieces = blackPieces;
            else
                pieces = whitePieces;

            var hasPiece = pieces.FirstOrDefault(x => x.StartRow == cell.Row && x.StartColumn == cell.Column);

            if (hasPiece != null)
            {
                pieces.Remove(hasPiece);
            }

            this.StartRow = cell.Row;
            this.StartColumn = cell.Column;
        }
    }
}
