using Domain.Models;

namespace Domain.IRepository
{
    public interface IUserRepository
    {
        public List<User> GetAllUsers();
        public User? GetUserById(Guid userId);
        public void InsertUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(User user);
    }
}
