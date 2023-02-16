using Repository.Dto;

namespace Service.ICustomServices
{
    public interface IUserService
    {
        public UserView CreateUser(UserRequest request);
        public UserView? GetUserById(string userId);
    }
}
