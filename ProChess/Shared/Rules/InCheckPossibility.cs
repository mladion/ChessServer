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

        /*
        public List<Cell> EvaluateListOfCellsPossibleForCheck(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cellsPossible_modificated = new();

            return cellsPossible_modificated;
        }
        */
        public bool EvaluateCellsForPossibleCheck(Piece? activePiece, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            bool itIsCheck;
            List<Piece> currentPieces = new List<Piece>();
            List<Piece> opponentPieces = new List<Piece>();

            // find out what color of figures are played by current player 
            if (activePiece.Color == PieceColor.White)
            {

                currentPieces = whitePieces;
                opponentPieces = blackPieces;
            }
            else
            {
                currentPieces = blackPieces;
                opponentPieces = whitePieces;
            }

            // detect possible check 
            itIsCheck = CheckTheMovesOfPawn(activePiece, whitePieces, blackPieces);
            if (itIsCheck == true) return true;
            itIsCheck = CheckTheMovesOfKnight(activePiece, opponentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = CheckTheMovesOfQueenAndRooK(activePiece, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = CheckTheMovesOfQueenAndBishop(activePiece, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;

            return false;
        }
        private bool CheckTheMovesOfPawn(Piece activePiece, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            bool itIsCheck;

            if (activePiece.Color == PieceColor.White)
            {
                itIsCheck = PawnAttack(activePiece.StartRow + _directionOffsets[0], activePiece.StartColumn + _directionOffsets[0], blackPieces);
                if (itIsCheck == true) return true;
                itIsCheck = PawnAttack(activePiece.StartRow + _directionOffsets[0], activePiece.StartColumn + _directionOffsets[1], blackPieces);
                return itIsCheck;
            }
            else
            {
                itIsCheck = PawnAttack(activePiece.StartRow + _directionOffsets[1], activePiece.StartColumn + _directionOffsets[0], whitePieces);
                if (itIsCheck == true) return true;
                itIsCheck = PawnAttack(activePiece.StartRow + _directionOffsets[1], activePiece.StartColumn + _directionOffsets[1], whitePieces);
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

        private bool CheckTheMovesOfKnight(Piece activePiece, List<Piece> currentPieces)
        {
            bool itIsCheck;

            itIsCheck = KnightAttack(activePiece.StartRow + _directionOffsets[2], activePiece.StartColumn + _directionOffsets[0], currentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(activePiece.StartRow + _directionOffsets[2], activePiece.StartColumn + _directionOffsets[1], currentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(activePiece.StartRow + _directionOffsets[3], activePiece.StartColumn + _directionOffsets[0], currentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(activePiece.StartRow + _directionOffsets[3], activePiece.StartColumn + _directionOffsets[1], currentPieces);
            if (itIsCheck == true) return true;

            itIsCheck = KnightAttack(activePiece.StartRow + _directionOffsets[0], activePiece.StartColumn + _directionOffsets[2], currentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(activePiece.StartRow + _directionOffsets[1], activePiece.StartColumn + _directionOffsets[2], currentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(activePiece.StartRow + _directionOffsets[0], activePiece.StartColumn + _directionOffsets[3], currentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = KnightAttack(activePiece.StartRow + _directionOffsets[1], activePiece.StartColumn + _directionOffsets[3], currentPieces);
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
        private bool CheckTheMovesOfQueenAndRooK(Piece activePiece, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            bool itIsCheck;

            itIsCheck = RookAndQueenAttackTop(activePiece, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = RookAndQueenAttackBottom(activePiece, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = RookAndQueenAttackRight(activePiece, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = RookAndQueenAttackLeft(activePiece, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;

            return itIsCheck;
        }
        private bool RookAndQueenAttackTop(Piece activePiece, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            for (var row = activePiece.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                Piece? currentPiece = currentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == activePiece.StartColumn);
                Piece? opponentPiece = opponentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == activePiece.StartColumn);

                if ((opponentPiece as Rook != null) || (opponentPiece as Queen != null))
                    return true;
                if ((currentPiece != null) || (opponentPiece != null))
                    return false;
            }
            return false;
        }
        private bool RookAndQueenAttackBottom(Piece activePiece, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            for (var row = activePiece.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                Piece? currentPiece = currentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == activePiece.StartColumn);
                Piece? opponentPiece = opponentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == activePiece.StartColumn);

                if ((opponentPiece as Rook != null) || (opponentPiece as Queen != null))
                    return true;
                if ((currentPiece != null) || (opponentPiece != null))
                    return false;
            }
            return false;
        }
        private bool RookAndQueenAttackRight(Piece activePiece, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            for (var column = activePiece.StartColumn + _directionOffsets[0]; column <= _edgeBoard[1]; column++)
            {
                Piece? currentPiece = currentPieces.FirstOrDefault(x => x.StartRow == activePiece.StartRow && x.StartColumn == column);
                Piece? opponentPiece = opponentPieces.FirstOrDefault(x => x.StartRow == activePiece.StartRow && x.StartColumn == column);

                if ((opponentPiece as Rook != null) || (opponentPiece as Queen != null))
                    return true;
                if ((currentPiece != null) || (opponentPiece != null))
                    return false;
            }
            return false;
        }
        private bool RookAndQueenAttackLeft(Piece activePiece, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            for (var column = activePiece.StartColumn + _directionOffsets[1]; column >= _edgeBoard[0]; column--)
            {
                Piece? currentPiece = currentPieces.FirstOrDefault(x => x.StartRow == activePiece.StartRow && x.StartColumn == column);
                Piece? opponentPiece = opponentPieces.FirstOrDefault(x => x.StartRow == activePiece.StartRow && x.StartColumn == column);

                if ((opponentPiece as Rook != null) || (opponentPiece as Queen != null))
                    return true;
                if ((currentPiece != null) || (opponentPiece != null))
                    return false;
            }
            return false;
        }

        private bool CheckTheMovesOfQueenAndBishop(Piece activePiece, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            bool itIsCheck;

            itIsCheck = BishopAndQueenAttackTopLeft(activePiece, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = BishopAndQueenAttackTopRight(activePiece, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = BishopAndQueenAttackBottomLeft(activePiece, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;
            itIsCheck = BishopAndQueenAttackBottomRight(activePiece, currentPieces, opponentPieces);
            if (itIsCheck == true) return true;

            return itIsCheck;
        }

        private bool BishopAndQueenAttackTopLeft(Piece activePiece, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            var column = activePiece.StartColumn;

            for (var row = activePiece.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                column--;
                if (column > _edgeBoard[1])
                    break;

                Piece? currentPiece = currentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);
                Piece? opponentPiece = opponentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

                if ((opponentPiece as Bishop != null) || (opponentPiece as Queen != null))
                    return true;
                if ((currentPiece != null) || (opponentPiece != null))
                    return false;
            }
            return false;
        }
        private bool BishopAndQueenAttackTopRight(Piece activePiece, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            var column = activePiece.StartColumn;

            for (var row = activePiece.StartRow + _directionOffsets[0]; row <= _edgeBoard[1]; row++)
            {
                column++;
                if (column > _edgeBoard[1])
                    break;   

                Piece? currentPiece = currentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);
                Piece? opponentPiece = opponentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

                if ((opponentPiece as Bishop != null) || (opponentPiece as Queen != null))
                    return true;
                if ((currentPiece != null) || (opponentPiece != null))
                    return false;
            }
            return false;
        }
        private bool BishopAndQueenAttackBottomLeft(Piece activePiece, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            var column = activePiece.StartColumn;

            for (var row = activePiece.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                column--;
                if (column > _edgeBoard[1])
                    break;

                Piece? currentPiece = currentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);
                Piece? opponentPiece = opponentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

                if ((opponentPiece as Bishop != null) || (opponentPiece as Queen != null))
                    return true;
                if ((currentPiece != null) || (opponentPiece != null))
                    return false;
            }
            return false;
        }
        private bool BishopAndQueenAttackBottomRight(Piece activePiece, List<Piece> currentPieces, List<Piece> opponentPieces)
        {
            var column = activePiece.StartColumn;

            for (var row = activePiece.StartRow + _directionOffsets[1]; row >= _edgeBoard[0]; row--)
            {
                column++;
                if (column > _edgeBoard[1])
                    break;

                Piece? currentPiece = currentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);
                Piece? opponentPiece = opponentPieces.FirstOrDefault(x => x.StartRow == row && x.StartColumn == column);

                if ((opponentPiece as Bishop != null) || (opponentPiece as Queen != null))
                    return true;
                if ((currentPiece != null) || (opponentPiece != null))
                    return false;
            }
            return false;
        }
    }
}
