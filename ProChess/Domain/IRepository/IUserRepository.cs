using Domain.Models;

namespace Domain.IRepository
{
    public interface IUserRepository
    {
        public List<ApplicationUser> GetAllUsers();
        public ApplicationUser? GetUserById(string userId);
        public void InsertUser(ApplicationUser user);
        public void UpdateUser(ApplicationUser user);
        public void DeleteUser(ApplicationUser user);
    }
}
