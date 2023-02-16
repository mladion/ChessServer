using Microsoft.AspNetCore.Mvc;
using Repository.Dto;
using Service.ICustomServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] UserRequest request)
        {
            var result = _userService.CreateUser(request);

            return Ok(result);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById([FromRoute] string userId)
        {
            var view = _userService.GetUserById(userId);

            return view != null ? Ok(view) : NotFound();
        }
    }
}
