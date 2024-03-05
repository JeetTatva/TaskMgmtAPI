using Microsoft.AspNetCore.Mvc;
using TaskMgmtApi.Models;
using TaskMgmtApi.Repositories;

namespace TaskMgmtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            try
            {
                return await _userRepository.GetUsers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Error occured while processing your request");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSingleUser(int id)
        {
            try
            {
                var user = await _userRepository.GetUser(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Error occured while processing your request");
            }

        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(string name, string email)
        {
            try
            {
                var user = await _userRepository.AddUser(name, email);
                if (user == null)
                {
                    return BadRequest("Failed to add user");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "An error occurred while processing your request");
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, string name, string email)
        {
            try
            {
                var user = await _userRepository.UpdateUser(id, name, email);
                if (user == null)
                {
                    return NotFound("User not found!");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "An error occurred while processing your request");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                var user = await _userRepository.DeleteUser(id);
                if (user == null)
                {
                    return NotFound("Failed to delete user");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "An error occurred while processing your request");
            }

        }

    }
}