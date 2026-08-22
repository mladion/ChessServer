namespace Shared.Models;

public class Move
{
    public int Id { get; set; }
    public int GameId { get; set; }
    public string? FromPosition { get; set; } // e.g., "a2"
    public string? ToPosition { get; set; }   // e.g., "a4"
    public string? PieceMoved { get; set; }   // e.g., "pawn"
    public DateTime MoveTime { get; set; }
    public int MoveNumber { get; set; }
}
