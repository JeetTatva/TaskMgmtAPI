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
            return  await _userRepository.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSingleUser(int id)
        {
            return await _userRepository.GetUser(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(string name, string email)
        {
            return await _userRepository.AddUser(name, email);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, string name, string email)
        {
            return await _userRepository.UpdateUser(id, name, email);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }

    }
}