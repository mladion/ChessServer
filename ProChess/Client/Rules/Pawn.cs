using Client.Data;

namespace Client.Rules
{
    public static class Pawn
    {
        private static List<int> columnsPossible { get; set; } = new();
        private static List<int> rowsPossible { get; set; } = new();

        public static List<int> EvaluateColumnsSpots(Piece piece)
        {
            columnsPossible.Add(piece.StartColumn);

            return columnsPossible;
        }

        public static List<int> EvaluateRowsSpots(Piece piece)
        {
            rowsPossible.Add(piece.Color == PieceColor.White ? piece.StartLine + 1 : piece.StartLine - 1);

            if (piece.StartLine == 6 || piece.StartLine == 1)
            {
                rowsPossible.Add(piece.Color == PieceColor.White ? piece.StartLine + 2 : piece.StartLine - 2);
            }

            return rowsPossible;
        }

        public static Piece Move(Piece piece, int row, int column)
        {
            piece.StartLine = row;
            piece.StartColumn = column;

            return piece;
        }
    }
}
