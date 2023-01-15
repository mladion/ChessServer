using System;
using Shared.Data;

namespace Shared.Rules
{
    public class Queen : Piece
    {
        public override List<Cell> EvaluateCells(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            Cell? cellPossible = null;
            List<Cell> cellsPossible = new();

            return cellsPossible;
        }
    }
}

