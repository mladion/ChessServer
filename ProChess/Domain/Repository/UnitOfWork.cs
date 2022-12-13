using Domain.IRepository;

namespace Domain.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChessDbContext _chessDbContext;

        public UnitOfWork(ChessDbContext chessDbContext)
        {
            _chessDbContext = chessDbContext;
            UserRepository = new UserRepository(_chessDbContext);
        }
        
        public IUserRepository UserRepository { get; }
        public void SaveChanges() => _chessDbContext.SaveChanges();
        public async Task SaveChangesAsync() => await _chessDbContext.SaveChangesAsync();
    }
}
