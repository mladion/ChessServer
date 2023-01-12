using Client.Data;

namespace Client.Rules
{
    public static class Pawn
    {
        private readonly static int[] _startingPositions = { 1, 6 };

        public static List<(int, int)> EvaluateCells(Piece piece, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var cellsPossible = new List<(int, int)>();

            (int, int)? move;

            move = EvaluateCellForMovement(piece.Color == PieceColor.White ? piece.StartRow + 1 : piece.StartRow - 1, piece.StartColumn, whitePieces, blackPieces);

            if (move != null)
                cellsPossible.Add(move.Value);

            if (cellsPossible.Any() && (piece.StartRow == _startingPositions[0] || piece.StartRow == _startingPositions[1]))
            {
                move = EvaluateCellForMovement(piece.Color == PieceColor.White ? piece.StartRow + 2 : piece.StartRow - 2, piece.StartColumn, whitePieces, blackPieces);

                if (move != null)
                    cellsPossible.Add(move.Value);
            }

            move = EvaluateCellForAttack(piece.Color == PieceColor.White ? piece.StartRow + 1 : piece.StartRow - 1, piece.StartColumn + 1, 
                piece.Color == PieceColor.White ? blackPieces : whitePieces);

            if (move != null)
                cellsPossible.Add(move.Value);

            move = EvaluateCellForAttack(piece.Color == PieceColor.White ? piece.StartRow + 1 : piece.StartRow - 1, piece.StartColumn - 1, 
                piece.Color == PieceColor.White ? blackPieces : whitePieces);

            if (move != null)
                cellsPossible.Add(move.Value);

            return cellsPossible;
        }

        private static (int, int)? EvaluateCellForMovement(int row, int column, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            var whitePiece = whitePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

            var blackPiece = blackPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

            if (whitePiece == null && blackPiece == null)
            {
                return (row, column);
            }

            return null;
        }

        private static (int, int)? EvaluateCellForAttack(int row, int column, List<Piece> pieces)
        {
            Piece? piece = pieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

            if (piece != null)
            {
                return (row, column);
            }

            return null;
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
