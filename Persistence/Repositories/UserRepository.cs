using Domain.Entities;
using Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MoodMateDbContext _context;

        public UserRepository(MoodMateDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
