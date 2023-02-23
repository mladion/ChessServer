using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequest request)
        {
            var newUser = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                Country = request.Country,
                Biography = request.Biography,
                ELO = request.ELO
            };

            var result = await _userManager.CreateAsync(newUser, request.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return Conflict(errors);
            }

            var user = new UserView
            {
                UserName = newUser.UserName,
                Email = newUser.Email,
                Password = newUser.PasswordHash,
                Country = newUser.Country,
                Biography = newUser.Biography,
                ELO = newUser.ELO
            };

            return Ok(user);
        }
    }
}
