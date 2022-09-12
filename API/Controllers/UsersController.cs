using Microsoft.AspNetCore.Mvc;
using AQUI_ESTOY.Models;
using AQUI_ESTOY.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AQUI_ESTOY.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet("{userId:int}")]
        public async Task<ActionResult<UserModel>> GetUserAsync(int userId)
        {
            try
            {
                var user = await _userService.GetUserAsync(userId);
                return Ok(user);
            }
            //catch (NotFoundElementException ex)
            //{
            //    return NotFound(ex.Message);
            //}
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something happend.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsersAsync()
        {
            try
            {
                var allUsers = await _userService.GetAllUsersAsync();
                return Ok(allUsers);
            }
            //catch (NotFoundElementException ex)
            //{
            //    return NotFound(ex.Message);
            //}
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something happend.");
            }
        }
    }
}