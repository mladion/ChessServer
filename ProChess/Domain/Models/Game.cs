using System;

namespace Domain.Models
{
	public class Game
	{
		public Guid Id { get; set; }
		public Guid? WhiteUserId { get; set; }
		public Guid? BlackUserId { get; set; }
		public int WhiteELO { get; set; }
		public int BlackELO { get; set; }
		public int WhiteRatingDiff { get; set; }
		public int BlackRatingDiff { get; set; }
		public string Result { get; set; } = "";
		public string GameMoves { get; set; } = "";
		public TimeOnly TimeControl { get; set; }
		public DateTime StartGameTime { get; set; } = DateTime.Now;
		public DateTime EndGameTime { get; set; }
        public User WhiteUser { get; set; } = new User();
        public User BlackUser { get; set; } = new User();
    }
}
