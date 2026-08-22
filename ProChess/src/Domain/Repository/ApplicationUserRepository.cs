using Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Domain.Repository;

public class ApplicationUserRepository : IRepository<ApplicationUser>
{
    private readonly ChessDbContext _context;

    public ApplicationUserRepository(ChessDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
    {
        return await _context.ApplicationUsers.AsNoTracking().ToListAsync();
    }

    public async Task<ApplicationUser?> GetByIdAsync(int id)
    {
        return await _context.ApplicationUsers.AsNoTracking().FirstOrDefaultAsync(u => u.Id == u.Id.ToString());
    }

    public async Task<ApplicationUser> AddAsync(ApplicationUser entity)
    {
        _context.ApplicationUsers.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<ApplicationUser> UpdateAsync(ApplicationUser entity)
    {
        _context.ApplicationUsers.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.ApplicationUsers.FindAsync(id.ToString());
        if (user != null)
        {
            _context.ApplicationUsers.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
