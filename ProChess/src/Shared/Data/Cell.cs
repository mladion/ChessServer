namespace Shared.Data
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool ContainsPiece { get; set; }

        public Cell(int row, int column, bool containsPiece = false)
        {
            Row = row;
            Column = column;
            ContainsPiece = containsPiece;
        }
    }
}
