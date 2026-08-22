using Microsoft.AspNetCore.Identity;

namespace Shared.Models;

public class ApplicationUser : IdentityUser
{
    public ICollection<Game> WhiteGames { get; set; } = [];
    public ICollection<Game> BlackGames { get; set; } = [];
}
