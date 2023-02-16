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

        public List<ApplicationUser> GetAllUsers()
        {
            return _chessDbContext.ApplicationUsers.ToList();
        }

        public ApplicationUser? GetUserById(string userId)
        {
            return _chessDbContext.ApplicationUsers.Find(userId);
        }

        public void InsertUser(ApplicationUser user)
        {
            _chessDbContext.Users.Add(user);
        }

        public void UpdateUser(ApplicationUser user)
        {
            _chessDbContext.Set<ApplicationUser>().Attach(user);
            _chessDbContext.Entry(user).State = EntityState.Modified;
        }

        public void DeleteUser(ApplicationUser user)
        {
            _chessDbContext.Users.Remove(user);
        }
    }
}
