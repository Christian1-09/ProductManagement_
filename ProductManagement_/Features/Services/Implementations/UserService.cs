using ProductManagement_.Features.Data.Models;
using ProductManagement_.Features.Respositories.Interface;
using ProductManagement_.Features.Services.Interface;
using System.Security.Cryptography;
using System.Text;

namespace ProductManagement_.Features.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo) => _repo = repo;

        public async Task RegisterAsync(UserAccount user)
        {
            var existing = await _repo.GetByUsernameAsync(user.Username);
            if (existing != null) throw new Exception("An account with this email already exists.");

            user.Password = Hash(user.Password);
            user.CreatedAt = DateTime.UtcNow;
            await _repo.AddAsync(user);
        }
        public async Task<UserAccount?> LoginAsync(string username, string password)
        {
            var user = await _repo.GetByUsernameAsync(username);
            if (user == null) return null;
            return user.Password == Hash(password) ? user : null;
        }
        public Task<List<UserAccount>> GetAllUsersAsync() => _repo.GetAllAsync();
        public async Task<UserAccount?> GetUserByIdAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            return user ?? throw new Exception($"User with ID {id} not found.");
        }
        public Task UpdateUserAsync(UserAccount user) => _repo.UpdateAsync(user);
       
        public Task DeleteUserAsync(int id) => _repo.DeleteAsync(id);
        
        private static string Hash(string input)
        {
            using var sha = SHA256.Create();
            return Convert.ToHexString(
                sha.ComputeHash(Encoding.UTF8.GetBytes(input)));
        }


    }
}
