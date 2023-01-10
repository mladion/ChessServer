using Client.Data;

namespace Client.Rules
{
    public static class Pawn
    {
        private static List<(int row, int column)> _cellsPossible { get; set; } = new();
        private static List<Piece> _whitePieces { get; set; } = new();
        private static List<Piece> _blackPieces { get; set; } = new();

        private static int[] _startingPositions = { 1, 6 };

        public static List<(int, int)> EvaluateCells(Piece piece, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            _cellsPossible.Clear();

            _whitePieces = whitePieces;
            _blackPieces = blackPieces;

            EvaluateCellForMovement(piece.Color == PieceColor.White ? piece.StartRow + 1 : piece.StartRow - 1, piece.StartColumn);

            if (_cellsPossible.Any() && (piece.StartRow == _startingPositions[0] || piece.StartRow == _startingPositions[1]))
            {
                EvaluateCellForMovement(piece.Color == PieceColor.White ? piece.StartRow + 2 : piece.StartRow - 2, piece.StartColumn);
            }

            EvaluateCellForAttack(piece, piece.Color == PieceColor.White ? piece.StartRow + 1 : piece.StartRow -1, piece.StartColumn + 1);
            EvaluateCellForAttack(piece, piece.Color == PieceColor.White ? piece.StartRow + 1 : piece.StartRow - 1, piece.StartColumn - 1);

            return _cellsPossible;
        }

        private static void EvaluateCellForMovement(int row, int column)
        {
            var whitePiece = _whitePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

            var blackPiece = _blackPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

            if (whitePiece == null && blackPiece == null)
            {
                _cellsPossible.Add((row, column));
            }
        }

        private static void EvaluateCellForAttack(Piece piece, int row, int column)
        {
            Piece? whitePiece = null;
            Piece? blackPiece = null;

            if (piece.Color == PieceColor.White)
            {
                blackPiece = _blackPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);
            }
            else
            {
                whitePiece = _whitePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);
            }

            if (whitePiece != null || blackPiece != null)
            {
                _cellsPossible.Add((row, column));
            }
        }

        public static void MoveOrAttack(Piece piece, int row, int column, List<Piece> pieces)
        {
            var hasPiece = pieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

            if (hasPiece != null)
            {
                pieces.Remove(hasPiece);
            }

            piece.StartRow = row;
            piece.StartColumn = column;
        }
    }
}
