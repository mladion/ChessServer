using Microsoft.VisualBasic;
using Shared.Data;
using Shared.Helpers.Extensions;
using System.Data.Common;

namespace Shared.Rules
{
    public class InCheckPossibility
    {
        private readonly int[] _directionOffsets = { 1, -1, 2, -2 };
        private readonly int[] _edgeBoard = { 0, 7 };

        public List<Cell> CouldPossibleCellsCreateCheck(Piece? activePiece, List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cellsPossible_modificated = new();

            return cellsPossible;
        }
        
        public Piece? EvaluateCellsForPossibleCheck(Piece? activePiece, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            bool itIsCheck;
            List<Piece> currentPieces = new List<Piece>();
            List<Piece> opponentPieces = new List<Piece>();
            Piece? opponentKing = null;

            var BKingHere = blackPieces.Where(x => x.GetType() == typeof(King)).FirstOrDefault();
            var kingBlack = new King();

            if (BKingHere != null)
                kingBlack = (King)BKingHere;

            var WKingHere = whitePieces.Where(x => x.GetType() == typeof(King)).FirstOrDefault();
            var kingWhite = new King();

            if (WKingHere != null)
                kingWhite = (King)WKingHere;

            // find out what color of figures are played by current player 
            if (activePiece.Color == PieceColor.White)
            {
                currentPieces = whitePieces;
                opponentPieces = blackPieces;
                opponentKing = kingBlack;
            }
            else
            {
                currentPieces = blackPieces;
                opponentPieces = whitePieces;
                opponentKing = kingWhite;
            }

            // detect possible check 
            itIsCheck = CheckTheMovesOfPawn(opponentKing, whitePieces, blackPieces);
            if (itIsCheck == true) return opponentKing;
            itIsCheck = CheckTheMovesOfKnight(opponentKing, currentPieces);
            if (itIsCheck == true) return opponentKing;
            itIsCheck = CheckTheMovesOfQueenAndRooK(opponentKing, currentPieces, opponentPieces);
            if (itIsCheck == true) return opponentKing;
            itIsCheck = CheckTheMovesOfQueenAndBishop(opponentKing, currentPieces, opponentPieces);
            if (itIsCheck == true) return opponentKing;

            return null;
        }
        private bool CheckTheMovesOfPawn(Piece opponentKing, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            bool itIsCheck;

            if (opponentKing.Color == PieceColor.White)
            {
                itIsCheck = PawnAttack(opponentKing.StartRow + _directionOffsets[0], opponentKing.StartColumn + _directionOffsets[0], blackPieces);
                if (itIsCheck == true) return true;
                itIsCheck = PawnAttack(opponentKing.StartRow + _directionOffsets[0], opponentKing.StartColumn + _directionOffsets[1], blackPieces);
                return itIsCheck;
            }
            else
            {
                itIsCheck = PawnAttack(opponentKing.StartRow + _directionOffsets[1], opponentKing.StartColumn + _directionOffsets[0], whitePieces);
                if (itIsCheck == true) return true;
                itIsCheck = PawnAttack(opponentKing.StartRow + _directionOffsets[1], opponentKing.StartColumn + _directionOffsets[1], whitePieces);
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

        private bool CheckTheMovesOfKnight(Piece opponentKing, List<Piece> currentPieces)
        {
            bool itIsCheck;

            itIsCheck = KnightAttack(opponentKing.StartRow + _directionOffsets[2], opponentKing.StartColumn + _directionOffsets[0], currentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(opponentKing.StartRow + _directionOffsets[2], opponentKing.StartColumn + _directionOffsets[1], currentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(opponentKing.StartRow + _directionOffsets[3], opponentKing.StartColumn + _directionOffsets[0], currentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(opponentKing.StartRow + _directionOffsets[3], opponentKing.StartColumn + _directionOffsets[1], currentPieces);
            if (itIsCheck == true) return true;

            itIsCheck = KnightAttack(opponentKing.StartRow + _directionOffsets[0], opponentKing.StartColumn + _directionOffsets[2], currentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(opponentKing.StartRow + _directionOffsets[1], opponentKing.StartColumn + _directionOffsets[2], currentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(opponentKing.StartRow + _directionOffsets[0], opponentKing.StartColumn + _directionOffsets[3], currentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(opponentKing.StartRow + _directionOffsets[1], opponentKing.StartColumn + _directionOffsets[3], currentPieces);
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
        private bool CheckTheMovesOfQueenAndRooK(Piece opponentKing, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            bool itIsCheck;

            itIsCheck = RookAndQueenAttackTop(opponentKing, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = RookAndQueenAttackBottom(opponentKing, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = RookAndQueenAttackRight(opponentKing, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = RookAndQueenAttackLeft(opponentKing, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;

            return itIsCheck;
        }
        private bool RookAndQueenAttackTop(Piece opponentKing, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            for (var row = opponentKing.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                Piece? currentPiece = currentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == opponentKing.StartColumn);
                Piece? opponentPiece = opponentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == opponentKing.StartColumn);

                if ((currentPiece as Rook != null) || (currentPiece as Queen != null))
                    return true;
                if ((currentPiece != null) || (opponentPiece != null))
                    return false;
            }
            return false;
        }
        private bool RookAndQueenAttackBottom(Piece opponentKing, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            for (var row = opponentKing.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                Piece? currentPiece = currentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == opponentKing.StartColumn);
                Piece? opponentPiece = opponentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == opponentKing.StartColumn);

                if ((currentPiece as Rook != null) || (currentPiece as Queen != null))
                    return true;
                if ((currentPiece != null) || (opponentPiece != null))
                    return false;
            }
            return false;
        }
        private bool RookAndQueenAttackRight(Piece opponentKing, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            for (var column = opponentKing.StartColumn + _directionOffsets[0]; column <= _edgeBoard[1]; column++)
            {
                Piece? currentPiece = currentPieces.FirstOrDefault(x => x.StartRow == opponentKing.StartRow && x.StartColumn == column);
                Piece? opponentPiece = opponentPieces.FirstOrDefault(x => x.StartRow == opponentKing.StartRow && x.StartColumn == column);

                if ((currentPiece as Rook != null) || (currentPiece as Queen != null))
                    return true;
                if ((currentPiece != null) || (opponentPiece != null))
                    return false;
            }
            return false;
        }
        private bool RookAndQueenAttackLeft(Piece opponentKing, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            for (var column = opponentKing.StartColumn + _directionOffsets[1]; column >= _edgeBoard[0]; column--)
            {
                Piece? currentPiece = currentPieces.FirstOrDefault(x => x.StartRow == opponentKing.StartRow && x.StartColumn == column);
                Piece? opponentPiece = opponentPieces.FirstOrDefault(x => x.StartRow == opponentKing.StartRow && x.StartColumn == column);

                if ((currentPiece as Rook != null) || (currentPiece as Queen != null))
                    return true;
                if ((currentPiece != null) || (opponentPiece != null))
                    return false;
            }
            return false;
        }

        private bool CheckTheMovesOfQueenAndBishop(Piece opponentKing, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            bool itIsCheck;

            itIsCheck = BishopAndQueenAttackTopLeft(opponentKing, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = BishopAndQueenAttackTopRight(opponentKing, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = BishopAndQueenAttackBottomLeft(opponentKing, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = BishopAndQueenAttackBottomRight(opponentKing, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;

            return itIsCheck;
        }

        private bool BishopAndQueenAttackTopLeft(Piece opponentKing, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            var column = opponentKing.StartColumn;

            for (var row = opponentKing.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                column--;
                if (column > _edgeBoard[1])
                    break;

                Piece? currentPiece = currentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);
                Piece? opponentPiece = opponentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

                if ((currentPiece as Bishop != null) || (currentPiece as Queen != null))
                    return true;
                if ((currentPiece != null) || (opponentPiece != null))
                    return false;
            }
            return false;
        }
        private bool BishopAndQueenAttackTopRight(Piece opponentKing, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            var column = opponentKing.StartColumn;

            for (var row = opponentKing.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                column++;
                if (column > _edgeBoard[1])
                    break;   

                Piece? currentPiece = currentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);
                Piece? opponentPiece = opponentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

                if ((currentPiece as Bishop != null) || (currentPiece as Queen != null))
                    return true;
                if ((currentPiece != null) || (opponentPiece != null))
                    return false;
            }
            return false;
        }
        private bool BishopAndQueenAttackBottomLeft(Piece opponentKing, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            var column = opponentKing.StartColumn;

            for (var row = opponentKing.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                column--;
                if (column > _edgeBoard[1])
                    break;

                Piece? currentPiece = currentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);
                Piece? opponentPiece = opponentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

                if ((currentPiece as Bishop != null) || (currentPiece as Queen != null))
                    return true;
                if ((currentPiece != null) || (opponentPiece != null))
                    return false;
            }
            return false;
        }
        private bool BishopAndQueenAttackBottomRight(Piece opponentKing, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            var column = opponentKing.StartColumn;

            for (var row = opponentKing.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                column++;
                if (column > _edgeBoard[1])
                    break;

                Piece? currentPiece = currentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);
                Piece? opponentPiece = opponentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

                if ((currentPiece as Bishop != null) || (currentPiece as Queen != null))
                    return true;
                if ((currentPiece != null) || (opponentPiece != null))
                    return false;
            }
            return false;
        }
    }
}
