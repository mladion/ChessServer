using Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Domain.Repository;

public class GameRepository : IGameRepository
{
    private readonly ChessDbContext _context;

    public GameRepository(ChessDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await _context.Games.AsNoTracking().ToListAsync();
    }

    public async Task<Game?> GetByIdAsync(int id)
    {
        return await _context.Games.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<Game> AddAsync(Game entity)
    {
        _context.Games.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Game> UpdateAsync(Game entity)
    {
        _context.Games.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game != null)
        {
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Game>> GetGamesByUserIdAsync(string userId)
    {
        return await _context.Games
            .Where(g => g.WhiteUserId == userId || g.BlackUserId == userId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Game?> GetGameWithPlayersAsync(int gameId)
    {
        return await _context.Games
            .Include(g => g.WhiteUser)
            .Include(g => g.BlackUser)
            .AsNoTracking()
            .FirstOrDefaultAsync(g => g.Id == gameId);
    }
}
