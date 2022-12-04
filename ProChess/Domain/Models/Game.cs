using System;

namespace Domain.Models
{
	public class Game
	{
		public Guid Id { get; set; }
		public Guid WhiteUser { get; set; }
		public Guid BlackUser { get; set; }
		public int WhiteELO { get; set; }
		public int BlackELO { get; set; }
		public int WhiteRatingDiff { get; set; }
		public int BlackRatingDiff { get; set; }
		public string Result { get; set; } = "";
		public string GameMoves { get; set; } = "";
		public TimeOnly TimeControl { get; set; }
		public DateTime StartGameTime { get; set; } = DateTime.Now;
		public DateTime EndGameTime { get; set; }
    }
}
