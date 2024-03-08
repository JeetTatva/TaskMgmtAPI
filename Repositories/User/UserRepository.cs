using Microsoft.EntityFrameworkCore;
using TaskMgmtApi.Data;
using TaskMgmtApi.Models;

namespace TaskMgmtApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers(int? pageNumber = null, int? pageSize = null) {
            IQueryable<User> query = _context.Users.OrderBy(u => u.Id);
            if(pageNumber.HasValue && pageSize.HasValue)
            {
                int itemsToSkip = (pageNumber.Value - 1) * pageSize.Value;
                query = query.Skip(itemsToSkip).Take(pageSize.Value);
            }
            List<User> users = await query.ToListAsync();
            return users;
        }

        public async Task<User?> GetUser(int id) {
            return await _context.Users.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<User?> AddUser(string name, string email) {
            int count = _context.Users.Count();
            User user = new User() {
                Id = count+1,
                Name = name,
                Email = email,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            // notification test
            return user;
        }

        public async Task<User?> UpdateUser(int id, string name, string email) {
            User? user = _context.Users.FirstOrDefault(item => item.Id == id);
            if(user != null) {
                user.Name = name;
                user.Email = email;
                user.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task<User?> DeleteUser(int id) {
            User? user = _context.Users.FirstOrDefault(item => item.Id == id);
            if(user != null) {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }
        
    }
}