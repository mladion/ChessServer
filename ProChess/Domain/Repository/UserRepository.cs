using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Domain.IRepository;

namespace Domain.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ChessDbContext _chessDbContext;

        public UserRepository(ChessDbContext chessDbContext)
        {
            _chessDbContext = chessDbContext;
        }

        public List<User> GetAllUsers()
        {
            return _chessDbContext.Users.ToList();
        }

        public User? GetUserById(Guid userId)
        {
            return _chessDbContext.Users.Find(userId);
        }

        public void InsertUser(User user)
        {
            _chessDbContext.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            _chessDbContext.Set<User>().Attach(user);
            _chessDbContext.Entry(user).State = EntityState.Modified;
        }

        public void DeleteUser(User user)
        {
            _chessDbContext.Users.Remove(user);
        }
    }
}
