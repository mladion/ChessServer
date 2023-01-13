using Shared.Data;

namespace Client.Data
{
    public abstract class Piece
    {
        public PieceColor Color { get; set; }
        public int StartRow { get; set; }
        public int StartColumn { get; set; }
        public string Image { get; set; } = "";

        public abstract List<Cell> EvaluateCells(List<Piece> whitePieces, List<Piece> blackPieces);

        public Cell? EvaluateCellForAttack(int row, int column, List<Piece> pieces)
        {
            Piece? piece = pieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

            if (piece != null)
            {
                return new Cell(row, column);
            }

            return null;
        }

        public void MoveOrAttack(Cell cell, List<Piece> pieces)
        {
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
