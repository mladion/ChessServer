using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
	public class User
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
		public string UserName { get; set; } = "";
		public string Email { get; set; } = "";
		public string Password { get; set; } = "";
		public string? Country { get; set; }
		public string? Biography { get; set; }
		public int ELO { get; set; }
		public Privileges Privilege { get; set; }
		public List<Game> WhiteGames { get; set; } = new List<Game>();
		public List<Game> BlackGames { get; set; } = new List<Game>();
	}
}
