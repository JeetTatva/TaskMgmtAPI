using TaskMgmtApi.Models;

namespace TaskMgmtApi.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers(int? pageNumber, int? pageSize);
        Task<User?> GetUser(int id);
        Task<User?> AddUser(string name, string email);
        Task<User?> UpdateUser(int id, string name, string email);
        Task<User?> DeleteUser(int id);
    }
}