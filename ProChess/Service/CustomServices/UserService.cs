using Domain.IRepository;
using Domain.Models;
using Repository.Dto;
using Service.ICustomServices;

namespace Service.CustomServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.UserRepository;
        }

        public UserView CreateUser(UserRequest request)
        {
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                Country = request.Country,
                Biography = request.Biography,
                ELO = request.ELO
            };

            _userRepository.InsertUser(user);
            _unitOfWork.SaveChanges();

            return new UserView
            {
                UserName = user.UserName,
                Email = user.Email,
                Country = user.Country,
                Biography = user.Biography,
                ELO = user.ELO
            };
        }

        public UserView? GetUserById(string userId)
        {
            var user = _userRepository.GetUserById(userId);

            if (user == null)
                return null;

            return new UserView
            {
                Country = user.Country,
                Biography = user.Biography,
                ELO = user.ELO,
                WhiteGames = user.WhiteGames,
                BlackGames= user.BlackGames
            };
        }
    }
}
