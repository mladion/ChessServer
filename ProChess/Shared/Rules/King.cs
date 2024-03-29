﻿using Microsoft.VisualBasic;
using Shared.Data;
using Shared.Helpers.Extensions;

namespace Shared.Rules
{
    public class King : Piece
    {
        public bool IsMoved { get; set; }

        private const int _columnCastleKingside = 6;
        private const int _columnCastleQueenside = 2;
        private readonly int[] _directionOffsets = { 1, -1 };
        private readonly int[] _edgeBoardAndRooksPosition = { 0, 7 };

        public override List<Cell> GetMovementPossibilities(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Cell> cellsPossible = new();

            cellsPossible.AddNotNullableItem(CheckTheMoveAhead(whitePieces, blackPieces));
            cellsPossible.AddNotNullableItem(CheckBackMove(whitePieces, blackPieces));
            cellsPossible.AddNotNullableItem(CheckTheMoveOnTheLeft(whitePieces, blackPieces));
            cellsPossible.AddNotNullableItem(CheckTheMoveOnTheRight(whitePieces, blackPieces));
            cellsPossible.AddNotNullableItem(CheckTheMoveOnTheTopLeftDiagonal(whitePieces, blackPieces));
            cellsPossible.AddNotNullableItem(CheckTheMoveOnTheTopRightDiagonal(whitePieces, blackPieces));
            cellsPossible.AddNotNullableItem(CheckTheMoveOnTheBottomLeftDiagonal(whitePieces, blackPieces));
            cellsPossible.AddNotNullableItem(CheckTheMoveOnTheBottomRightDiagonal(whitePieces, blackPieces));

            if (!this.IsMoved)
            {
                CheckCastlingKingside(cellsPossible, whitePieces, blackPieces);
                CheckCastlingQueenside(cellsPossible, whitePieces, blackPieces);
            }

            return cellsPossible;
        }

        public override Cell? EvaluateCellForMovement(int row, int column, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            if (row >= _edgeBoardAndRooksPosition[0] && column >= _edgeBoardAndRooksPosition[0] &&
                row <= _edgeBoardAndRooksPosition[1] && column <= _edgeBoardAndRooksPosition[1])
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
                    if (!this.IsMoved && (column == _columnCastleQueenside || column == _columnCastleKingside))
                        return null;

                    return new Cell(row, column, true);
                }
            }

            return null;
        }

        public override void MoveOrAttack(Cell cell, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            base.MoveOrAttack(cell, whitePieces, blackPieces);

            if (!this.IsMoved && (this.StartColumn == _columnCastleKingside || this.StartColumn == _columnCastleQueenside))
            {
                if (this.Color == PieceColor.White)
                {
                    if (this.StartColumn == _columnCastleKingside)
                        MoveRookForCastle(whitePieces, _edgeBoardAndRooksPosition[1], _columnCastleKingside + _directionOffsets[1]);
                    else
                        MoveRookForCastle(whitePieces, _edgeBoardAndRooksPosition[0], _columnCastleQueenside + _directionOffsets[0]);
                }
                else
                {
                    if (this.StartColumn == _columnCastleKingside)
                        MoveRookForCastle(blackPieces, _edgeBoardAndRooksPosition[1], _columnCastleKingside + _directionOffsets[1]);
                    else
                        MoveRookForCastle(blackPieces, _edgeBoardAndRooksPosition[0], _columnCastleQueenside + _directionOffsets[0]);
                }
            }

            this.IsMoved = true;
        }

        private void MoveRookForCastle(List<Piece> pieces, int columnOfTheTargetedRook, int finalDestinationForRook)
        {
            Piece? localPiece = pieces.Where(x => x.GetType() == typeof(Rook) &&
                x.StartRow == this.StartRow && x.StartColumn == columnOfTheTargetedRook).FirstOrDefault();

            if (localPiece != null)
            {
                var rook = (Rook)localPiece;

                if (!rook.IsMoved)
                {
                    rook.StartColumn = finalDestinationForRook;
                }
            }
        }

        private Cell? CheckTheMoveAhead(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            return EvaluateCellForMovement(this.StartRow + _directionOffsets[0], this.StartColumn, whitePieces, blackPieces);
        }

        private Cell? CheckBackMove(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            return EvaluateCellForMovement(this.StartRow + _directionOffsets[1], this.StartColumn, whitePieces, blackPieces);
        }

        private Cell? CheckTheMoveOnTheLeft(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            return EvaluateCellForMovement(this.StartRow, this.StartColumn + _directionOffsets[1], whitePieces, blackPieces);
        }

        private Cell? CheckTheMoveOnTheRight(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            return EvaluateCellForMovement(this.StartRow, this.StartColumn + _directionOffsets[0], whitePieces, blackPieces);
        }

        private Cell? CheckTheMoveOnTheTopLeftDiagonal(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            return EvaluateCellForMovement(this.StartRow + _directionOffsets[0], this.StartColumn + _directionOffsets[1], whitePieces, blackPieces);
        }

        private Cell? CheckTheMoveOnTheTopRightDiagonal(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            return EvaluateCellForMovement(this.StartRow + _directionOffsets[0], this.StartColumn + _directionOffsets[0], whitePieces, blackPieces);
        }

        private Cell? CheckTheMoveOnTheBottomLeftDiagonal(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            return EvaluateCellForMovement(this.StartRow + _directionOffsets[1], this.StartColumn + _directionOffsets[1], whitePieces, blackPieces);
        }

        private Cell? CheckTheMoveOnTheBottomRightDiagonal(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            return EvaluateCellForMovement(this.StartRow + _directionOffsets[1], this.StartColumn + _directionOffsets[0], whitePieces, blackPieces);
        }

        private void CheckCastlingKingside(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            if (!this.IsMoved)
            {
                EvaluateCellsForCastle(cellsPossible, whitePieces, blackPieces, _edgeBoardAndRooksPosition[1]);
            }
        }

        private void CheckCastlingQueenside(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            if (!this.IsMoved)
            {
                EvaluateCellsForCastle(cellsPossible, whitePieces, blackPieces, _edgeBoardAndRooksPosition[0]);
            }
        }

        public void EvaluateCellsForCastle(List<Cell> cellsPossible, List<Piece> whitePieces, List<Piece> blackPieces, int rookColumn)
        {
            Piece? piece = null;

            if (this.Color == PieceColor.White)
            {
                piece = whitePieces.Find(x => x.StartRow == _edgeBoardAndRooksPosition[0] &&
                    x.StartColumn == rookColumn);
            }
            else
            {
                piece = blackPieces.Find(x => x.StartRow == _edgeBoardAndRooksPosition[1] &&
                    x.StartColumn == rookColumn);
            }

            Rook rook = new Rook();

            if (piece != null && piece.GetType() == typeof(Rook))
            {
                rook = (Rook)piece;

                if (!rook.IsMoved)
                {
                    if (rookColumn > this.StartColumn)
                    {
                        for (int column = this.StartColumn + _directionOffsets[0]; column < rook.StartColumn; column++)
                        {
                            var cellPossible = EvaluateCellForMovement(this.StartRow, column, whitePieces, blackPieces);

                            if (cellPossible is null)
                                break;

                            if (!cellsPossible.Any(x => x.Row == cellPossible.Row && x.Column == cellPossible.Column))
                                cellsPossible.Add(cellPossible);
                        }
                    }
                    else
                    {
                        for (int column = rook.StartColumn + _directionOffsets[0]; column < this.StartColumn; column++)
                        {
                            var cellPossible = EvaluateCellForMovement(this.StartRow, column, whitePieces, blackPieces);

                            if (cellPossible is null)
                            {
                                if (column == this.StartColumn + _directionOffsets[1] && cellsPossible.Count > 0)
                                {
                                    cellsPossible.RemoveAt(cellsPossible.Count - 1);
                                }

                                break;
                            }

                            if (column > rook.StartColumn + _directionOffsets[0])
                            {
                                if (!cellsPossible.Any(x => x.Row == cellPossible.Row && x.Column == cellPossible.Column))
                                    cellsPossible.Add(cellPossible);
                            }
                        }
                    }
                }
            }
        }
    }
}
