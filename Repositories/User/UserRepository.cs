using TaskMgmtApi.Models;

namespace TaskMgmtApi.Repositories
{

    public class UserRepository : IUserRepository
    {
        private static List<User> DataSource()
        {
            return
            [
                new User { Id = 1, Name = "Lewis", Email = "lewis@gmail.com", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new User { Id = 2, Name = "Russell", Email = "russell@gmail.com", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new User { Id = 3, Name = "Max", Email = "max@gmail.com", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
            ];
        }

        public List<User> GetUsers()
        {
            return DataSource();
        }

        public User GetUser(int id)
        {
            return DataSource().FirstOrDefault(item => item.Id == id);
        }

        public User AddUser(string name, string email) {
            List<User> users = GetUsers();
            User newUser = new User { Id = users.Count + 1, Name = name, Email = email, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };
            DataSource().Add(newUser);
            return newUser;
        }

        public User UpdateUser(int id, string name, string email) {
            User user = DataSource().FirstOrDefault(item => item.Id == id);
            if(user is not null) {
                user.Name = name;
                user.Email = email;
            };
            return user;
        }

        public User DeleteUser(int id) {
            User user = DataSource().FirstOrDefault(item => item.Id == id);
            if(user is not null) {
                DataSource().Remove(user);
            }
            return user;
        }
    }
}