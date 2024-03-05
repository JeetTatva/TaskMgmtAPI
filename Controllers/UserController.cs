using Microsoft.AspNetCore.Mvc;
using TaskMgmtApi.Models;
using TaskMgmtApi.Repositories;

namespace TaskMgmtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return  _userRepository.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSingleUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(string name, string email)
        {
            return _userRepository.AddUser(name, email);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, string name, string email)
        {
            return _userRepository.UpdateUser(id, name, email);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

    }
}