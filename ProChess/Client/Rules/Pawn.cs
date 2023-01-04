using Client.Data;

namespace Client.Rules
{
    public static class Pawn
    {
        private static List<(int row, int column)> cellsPossible { get; set; } = new();
        private static List<Piece> whitePieces { get; set; } = new();
        private static List<Piece> blackPieces { get; set; } = new();

        public static List<(int, int)> EvaluateCells(Piece piece, List<Piece> wPieces, List<Piece> bPieces)
        {
            cellsPossible.Clear();

            whitePieces = wPieces; blackPieces = bPieces;

            EvaluateCell(piece.Direction == PieceDirection.Up ? piece.StartRow + 1 : piece.StartRow - 1, piece.StartColumn);

            if (cellsPossible.Any() && (piece.StartRow == 6 || piece.StartRow == 1))
            {
                EvaluateCell(piece.Direction == PieceDirection.Up ? piece.StartRow + 2 : piece.StartRow - 2, piece.StartColumn);
            }

            return cellsPossible;
        }

        private static void EvaluateCell(int row, int column)
        {
            var wPieces = whitePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

            var bPieces = blackPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

            if (wPieces == null && bPieces == null)
            {
                cellsPossible.Add((row, column));
            }
        }

        public static Piece Move(Piece piece, int row, int column)
        {
            piece.StartRow = row;
            piece.StartColumn = column;

            return piece;
        }
    }
}
