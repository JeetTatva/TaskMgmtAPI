using Microsoft.AspNetCore.Mvc;
using TaskMgmtApi.Models;

namespace TaskMgmtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = [
            new User
            {
                Id = 1,
                Name = "Jeet",
                Email = "jeet@test.com",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }
        ];

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSingleUser(int id)
        {
            var user = users.Find(x => x.Id == id);
            if (user is null)
            {
                return NotFound("User not found!");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            users.Add(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User request)
        {
            var user = users.Find(x => x.Id == id);
            if(user is null) {
                return NotFound("User not found");
            }
            user.Name = request.Name;
            user.Email = request.Email;
            user.UpdatedAt = DateTime.Now;
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = users.Find(x => x.Id == id);
            if(user is null) {
                return NotFound("User not found");
            }
            users.Remove(user);
            return Ok(user);
        }

    }
}