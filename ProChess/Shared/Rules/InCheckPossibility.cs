using Shared.Data;

namespace Shared.Rules
{
    public class InCheckPossibility
    {
        private readonly int[] _directionOffsets = { 1, -1, 2, -2 };
        private readonly int[] _edgeBoard = { 0, 7 };

        public List<Cell> CouldPossibleCellsCreateCheck(Piece activePiece, List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Piece> whitePiecesCopy = new();
            foreach (var piece in whitePieces)
            {
                whitePiecesCopy.Add(piece.Clone(piece));
            }

            List<Piece> blackPiecesCopy = new();
            foreach (var piece in blackPieces)
            {
                blackPiecesCopy.Add(piece.Clone(piece));
            }

            var activePieceCopy = whitePiecesCopy.FirstOrDefault(x => x.StartColumn == activePiece.StartColumn && x.StartRow == activePiece.StartRow);
            activePieceCopy ??= blackPiecesCopy.FirstOrDefault(x => x.StartColumn == activePiece.StartColumn && x.StartRow == activePiece.StartRow);

            var BKingHere = blackPiecesCopy.Where(x => x.GetType() == typeof(King)).FirstOrDefault();
            var kingBlack = new King();

            if (BKingHere != null)
                kingBlack = (King)BKingHere;

            var WKingHere = whitePiecesCopy.Where(x => x.GetType() == typeof(King)).FirstOrDefault();
            var kingWhite = new King();

            if (WKingHere != null)
                kingWhite = (King)WKingHere;

            Piece? KingUnderAtack = null;
            List<Piece> kingSidePieces = new();
            List<Piece> opponentSidePieces = new();
            Piece? theKingPiece = null;

            if (activePiece.Color == PieceColor.White)
            {
                theKingPiece = kingWhite;
                kingSidePieces = whitePiecesCopy;
                opponentSidePieces = blackPiecesCopy;
            }
            else
            {
                theKingPiece = kingBlack;
                kingSidePieces = blackPiecesCopy;
                opponentSidePieces = whitePiecesCopy;
            }

            List<Cell> cellsPossibleModificated = new(); 

            for (int i = 0; i < cellsPossible.Count; i++) // pasing of list of possible moves for active figure 
            {
                var cell = cellsPossible[i];
                Piece? hasPiece = null;

                if (cell.ContainsPiece == true)
                {
                    hasPiece = opponentSidePieces.FirstOrDefault(x => x.StartRow == cell.Row && x.StartColumn == cell.Column);

                    if (hasPiece != null)
                    {
                        opponentSidePieces.Remove(hasPiece);
                    }
                }
                if (activePieceCopy != null)
                {
                    activePieceCopy.StartRow = cell.Row;
                    activePieceCopy.StartColumn = cell.Column;
                }

                KingUnderAtack = DetectPossibleCheck(theKingPiece, kingSidePieces, opponentSidePieces);// verification if move from above create check 

                if (KingUnderAtack == null)
                {
                     cellsPossibleModificated.Add(cell);
                }

                if (hasPiece != null)
                {
                    opponentSidePieces.Add(hasPiece);
                }
            }

            return cellsPossibleModificated;
        }
        
        public Piece? EvaluateCellsForPossibleCheck(Piece? kingPiece, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Piece> kingSidePieces = new();
            List<Piece> opponentSidePieces = new();
            Piece? theKingPiece = null;

            if (kingPiece?.Color == PieceColor.White)
            {
                theKingPiece = kingPiece;
                kingSidePieces = whitePieces;
                opponentSidePieces = blackPieces;
            }
            else if (kingPiece?.Color == PieceColor.Black)
            {
                theKingPiece = kingPiece;
                kingSidePieces = blackPieces;
                opponentSidePieces = whitePieces;
            }

            if (theKingPiece != null)
                return DetectPossibleCheck(theKingPiece, kingSidePieces, opponentSidePieces);

            return null;
        }

        private Piece? DetectPossibleCheck(Piece theKingPiece, List<Piece> kingSidePieces, List<Piece> opponentSidePieces)
        {
            bool itIsCheck;

            itIsCheck = CheckTheMovesOfPawn(theKingPiece, opponentSidePieces);
            if (itIsCheck == true)
                return theKingPiece;

            itIsCheck = CheckTheMovesOfKnight(theKingPiece, opponentSidePieces);
            if (itIsCheck == true)
                return theKingPiece;

            itIsCheck = CheckTheMovesOfQueenAndRook(theKingPiece, kingSidePieces, opponentSidePieces);
            if (itIsCheck == true)
                return theKingPiece;

            itIsCheck = CheckTheMovesOfQueenAndBishop(theKingPiece, kingSidePieces, opponentSidePieces);
            if (itIsCheck == true)
                return theKingPiece;

            return null;
        }

        private bool CheckTheMovesOfPawn(Piece theKingPiece, List<Piece> opponentSidePieces)
        {
            bool itIsCheck;

            if (theKingPiece.Color == PieceColor.White)
            {
                itIsCheck = PawnAttack(theKingPiece.StartRow + _directionOffsets[0], theKingPiece.StartColumn + _directionOffsets[0], opponentSidePieces);
                if (itIsCheck)
                    return itIsCheck;

                itIsCheck = PawnAttack(theKingPiece.StartRow + _directionOffsets[0], theKingPiece.StartColumn + _directionOffsets[1], opponentSidePieces);
                return itIsCheck;
            }
            else
            {
                itIsCheck = PawnAttack(theKingPiece.StartRow + _directionOffsets[1], theKingPiece.StartColumn + _directionOffsets[0], opponentSidePieces);
                if (itIsCheck)
                    return itIsCheck;

                itIsCheck = PawnAttack(theKingPiece.StartRow + _directionOffsets[1], theKingPiece.StartColumn + _directionOffsets[1], opponentSidePieces);
                return itIsCheck;
            }
        }
        private bool PawnAttack(int row, int column, List<Piece> pieces)
        {
            Piece? piece = pieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

            if (piece as Pawn != null)
            {
                return true;
            }

            return false;
        }

        private bool CheckTheMovesOfKnight(Piece theKingPiece, List<Piece> opponentSidePieces)
        {
            bool itIsCheck;

            itIsCheck = KnightAttack(theKingPiece.StartRow + _directionOffsets[2], theKingPiece.StartColumn + _directionOffsets[0], opponentSidePieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(theKingPiece.StartRow + _directionOffsets[2], theKingPiece.StartColumn + _directionOffsets[1], opponentSidePieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(theKingPiece.StartRow + _directionOffsets[3], theKingPiece.StartColumn + _directionOffsets[0], opponentSidePieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(theKingPiece.StartRow + _directionOffsets[3], theKingPiece.StartColumn + _directionOffsets[1], opponentSidePieces);
            if (itIsCheck == true) return true;

            itIsCheck = KnightAttack(theKingPiece.StartRow + _directionOffsets[0], theKingPiece.StartColumn + _directionOffsets[2], opponentSidePieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(theKingPiece.StartRow + _directionOffsets[1], theKingPiece.StartColumn + _directionOffsets[2], opponentSidePieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(theKingPiece.StartRow + _directionOffsets[0], theKingPiece.StartColumn + _directionOffsets[3], opponentSidePieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(theKingPiece.StartRow + _directionOffsets[1], theKingPiece.StartColumn + _directionOffsets[3], opponentSidePieces);
            if (itIsCheck == true) return true;

            return itIsCheck;
        }
        private bool KnightAttack(int row, int column, List<Piece> pieces)
        {
            Piece? piece = pieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

            if (piece as Knight != null)
            {
                return true;
            }

            return false;
        }

        private bool CheckTheMovesOfQueenAndRook(Piece theKingPiece, List<Piece> kingSidePieces, List<Piece> opponentSidePieces)
        {
            bool itIsCheck;

            itIsCheck = RookAndQueenAttackTop(theKingPiece, kingSidePieces, opponentSidePieces);
            if (itIsCheck == true) return true;
            itIsCheck = RookAndQueenAttackBottom(theKingPiece, kingSidePieces, opponentSidePieces);
            if (itIsCheck == true) return true;
            itIsCheck = RookAndQueenAttackRight(theKingPiece, kingSidePieces, opponentSidePieces);
            if (itIsCheck == true) return true;
            itIsCheck = RookAndQueenAttackLeft(theKingPiece, kingSidePieces, opponentSidePieces);
            if (itIsCheck == true) return true;

            return itIsCheck;
        }
        private bool RookAndQueenAttackTop(Piece theKingPiece, List<Piece> kingSidePieces, List<Piece> opponentSidePieces)
        {
            for (var row = theKingPiece.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                Piece? opponentSide = opponentSidePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == theKingPiece.StartColumn);
                Piece? kingSide = kingSidePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == theKingPiece.StartColumn);

                if ((opponentSide as Rook != null) || (opponentSide as Queen != null))
                    return true;

                if ((opponentSide != null) || (kingSide != null))
                    return false;
            }

            return false;
        }
        private bool RookAndQueenAttackBottom(Piece theKingPiece, List<Piece> kingSidePieces, List<Piece> opponentSidePieces)
        {
            for (var row = theKingPiece.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                Piece? opponentSide = opponentSidePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == theKingPiece.StartColumn);
                Piece? kingSide = kingSidePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == theKingPiece.StartColumn);

                if ((opponentSide as Rook != null) || (opponentSide as Queen != null))
                    return true;

                if ((opponentSide != null) || (kingSide != null))
                    return false;
            }

            return false;
        }
        private bool RookAndQueenAttackRight(Piece theKingPiece, List<Piece> kingSidePieces, List<Piece> opponentSidePieces)
        {
            for (var column = theKingPiece.StartColumn + _directionOffsets[0]; column <= _edgeBoard[1]; column++)
            {
                Piece? opponentSide = opponentSidePieces.FirstOrDefault(x => x.StartRow == theKingPiece.StartRow && x.StartColumn == column);
                Piece? kingSide = kingSidePieces.FirstOrDefault(x => x.StartRow == theKingPiece.StartRow && x.StartColumn == column);

                if ((opponentSide as Rook != null) || (opponentSide as Queen != null))
                    return true;

                if ((opponentSide != null) || (kingSide != null))
                    return false;
            }
            return false;
        }
        private bool RookAndQueenAttackLeft(Piece theKingPiece, List<Piece> kingSidePieces, List<Piece> opponentSidePieces)
        {
            for (var column = theKingPiece.StartColumn + _directionOffsets[1]; column >= _edgeBoard[0]; column--)
            {
                Piece? opponentSide = opponentSidePieces.FirstOrDefault(x => x.StartRow == theKingPiece.StartRow && x.StartColumn == column);
                Piece? kingSide = kingSidePieces.FirstOrDefault(x => x.StartRow == theKingPiece.StartRow && x.StartColumn == column);

                if ((opponentSide as Rook != null) || (opponentSide as Queen != null))
                    return true;
                if ((opponentSide != null) || (kingSide != null))
                    return false;
            }

            return false;
        }
        private bool CheckTheMovesOfQueenAndBishop(Piece theKingPiece, List<Piece> kingSidePieces, List<Piece> opponentSidePieces)
        {
            bool itIsCheck;

            itIsCheck = BishopAndQueenAttackTopLeft(theKingPiece, kingSidePieces, opponentSidePieces);
            if (itIsCheck == true) return true;
            itIsCheck = BishopAndQueenAttackTopRight(theKingPiece, kingSidePieces, opponentSidePieces);
            if (itIsCheck == true) return true;
            itIsCheck = BishopAndQueenAttackBottomLeft(theKingPiece, kingSidePieces, opponentSidePieces);
            if (itIsCheck == true) return true;
            itIsCheck = BishopAndQueenAttackBottomRight(theKingPiece, kingSidePieces, opponentSidePieces);
            if (itIsCheck == true) return true;

            return itIsCheck;
        }
        private bool BishopAndQueenAttackTopLeft(Piece theKingPiece, List<Piece> kingSidePieces, List<Piece> opponentSidePieces)
        {
            var column = theKingPiece.StartColumn;

            for (var row = theKingPiece.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                column--;
                if (column > _edgeBoard[1])
                    break;

                Piece? opponentSide = opponentSidePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);
                Piece? kingSide = kingSidePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

                if ((opponentSide as Bishop != null) || (opponentSide as Queen != null))
                    return true;

                if ((opponentSide != null) || (kingSide != null))
                    return false;
            }

            return false;
        }
        private bool BishopAndQueenAttackTopRight(Piece theKingPiece, List<Piece> kingSidePieces, List<Piece> opponentSidePieces)
        {
            var column = theKingPiece.StartColumn;

            for (var row = theKingPiece.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                column++;
                if (column > _edgeBoard[1])
                    break;   

                Piece? opponentSide = opponentSidePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);
                Piece? kingSide = kingSidePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

                if ((opponentSide as Bishop != null) || (opponentSide as Queen != null))
                    return true;

                if ((opponentSide != null) || (kingSide != null))
                    return false;
            }

            return false;
        }
        private bool BishopAndQueenAttackBottomLeft(Piece theKingPiece, List<Piece> kingSidePieces, List<Piece> opponentSidePieces)
        {
            var column = theKingPiece.StartColumn;

            for (var row = theKingPiece.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                column--;
                if (column > _edgeBoard[1])
                    break;

                Piece? opponentSide = opponentSidePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);
                Piece? kingSide = kingSidePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

                if ((opponentSide as Bishop != null) || (opponentSide as Queen != null))
                    return true;

                if ((opponentSide != null) || (kingSide != null))
                    return false;
            }

            return false;
        }
        private bool BishopAndQueenAttackBottomRight(Piece theKingPiece, List<Piece> kingSidePieces, List<Piece> opponentSidePieces)
        {
            var column = theKingPiece.StartColumn;

            for (var row = theKingPiece.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                column++;
                if (column > _edgeBoard[1])
                    break;

                Piece? opponentSide = opponentSidePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);
                Piece? kingSide = kingSidePieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

                if ((opponentSide as Bishop != null) || (opponentSide as Queen != null))
                    return true;

                if ((opponentSide != null) || (kingSide != null))
                    return false;
            }

            return false;
        }
    }
}
