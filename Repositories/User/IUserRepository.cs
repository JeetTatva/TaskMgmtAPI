using TaskMgmtApi.Models;

namespace TaskMgmtApi.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUser(int id);
        User AddUser(string name, string email);
        User UpdateUser(int id, string name, string email);
        User DeleteUser(int id);
    }
}