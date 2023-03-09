using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
	public class ApplicationUser : IdentityUser
	{
        public string? Country { get; set; }
		public string? Biography { get; set; }
		public int ELO { get; set; }
		public List<Game> WhiteGames { get; set; } = new List<Game>();
		public List<Game> BlackGames { get; set; } = new List<Game>();
	}
}
