namespace Client.Data
{
    public class Piece
    {
        public PieceType Name { get; set; }
        public PieceColor Color { get; set; }
        public PieceDirection Direction { get; set; }
        public int StartPositionX { get; set; }
        public int StartPositionY { get; set; }
        public string Image { get; set; } = "";
    }
}
