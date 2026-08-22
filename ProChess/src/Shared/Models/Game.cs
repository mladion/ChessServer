namespace Shared.Models;

public class Game
{
    public int Id { get; set; }
    public string? WhiteUserId { get; set; }
    public string? BlackUserId { get; set; }
    public ApplicationUser? WhiteUser { get; set; }
    public ApplicationUser? BlackUser { get; set; }
    public string Status { get; set; } = "Active"; // Active, Completed, Abandoned
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? EndedAt { get; set; }
    public string? Winner { get; set; } // "White", "Black", "Draw"
}
