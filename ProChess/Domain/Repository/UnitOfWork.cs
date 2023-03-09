using Domain.IRepository;

namespace Domain.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChessDbContext _chessDbContext;

        public UnitOfWork(ChessDbContext chessDbContext)
        {
            _chessDbContext = chessDbContext;
        }
        
        public void SaveChanges() => _chessDbContext.SaveChanges();
        public async Task SaveChangesAsync() => await _chessDbContext.SaveChangesAsync();
    }
}
