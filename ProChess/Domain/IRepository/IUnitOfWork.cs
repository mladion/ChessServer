namespace Domain.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
