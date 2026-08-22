using Shared.Models;

namespace Domain.IRepository;

public interface IGameRepository : IRepository<Game>
{
    Task<IEnumerable<Game>> GetGamesByUserIdAsync(string userId);
    Task<Game?> GetGameWithPlayersAsync(int gameId);
}
