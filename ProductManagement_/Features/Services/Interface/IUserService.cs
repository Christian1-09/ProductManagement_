using ProductManagement_.Features.Data.Models;

namespace ProductManagement_.Features.Services.Interface
{
    public interface IUserService
    {
        Task RegisterAsync(UserAccount user);
        Task<UserAccount?> LoginAsync(string username, string password);
        Task<List<UserAccount>> GetAllUsersAsync();
        Task<UserAccount?> GetUserByIdAsync(int id);
        Task UpdateUserAsync(UserAccount user);
        Task DeleteUserAsync(int id);
    }
}
