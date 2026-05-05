using Microsoft.EntityFrameworkCore;
using ProductManagement_.Features.Data;
using ProductManagement_.Features.Data.Models;
using ProductManagement_.Features.Respositories.Interface;

namespace ProductManagement_.Features.Respositories.Implementations
{
    public class UserRepository : GenericRepository<UserAccount>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }
        public async Task<UserAccount?> GetByUsernameAsync(string username) =>
            await _dbSet.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        
    }
}
