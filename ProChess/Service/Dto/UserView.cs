using Domain.Models;

namespace Repository.Dto
{
    public class UserView
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string? Country { get; set; }
        public string? Biography { get; set; }
        public int ELO { get; set; }
        public List<Game>? WhiteGames { get; set; }
        public List<Game>? BlackGames { get; set; }
    }
}
