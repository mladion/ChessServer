using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
	public class Game
	{
        public Guid Id { get; set; }

		[ForeignKey(nameof(WhiteUser))]
		public string? WhiteUserId { get; set; }

        [ForeignKey(nameof(BlackUser))]
        public string? BlackUserId { get; set; }

		public int WhiteELO { get; set; }
		public int BlackELO { get; set; }
		public int WhiteRatingDiff { get; set; }
		public int BlackRatingDiff { get; set; }
		public string Result { get; set; } = "";
		public string GameMoves { get; set; } = "";
		public TimeOnly TimeControl { get; set; }
		public DateTime StartGameTime { get; set; } = DateTime.Now;
		public DateTime EndGameTime { get; set; }
        public virtual ApplicationUser WhiteUser { get; set; } = new ApplicationUser();
        public virtual ApplicationUser BlackUser { get; set; } = new ApplicationUser();
    }
}
