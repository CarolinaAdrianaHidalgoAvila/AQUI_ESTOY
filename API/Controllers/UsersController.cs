using Microsoft.AspNetCore.Mvc;
using AQUI_ESTOY.Models;
using AQUI_ESTOY.Services;
namespace AQUI_ESTOY.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUserAsync([FromBody] UserModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var newUser = await _userService.CreateUserAsync(user);
                return Created($"/api/users/{newUser.Id}", newUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something happend.");
            }
        }
    }
}