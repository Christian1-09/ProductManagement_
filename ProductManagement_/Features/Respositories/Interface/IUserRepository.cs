using ProductManagement_.Features.Data.Models;

namespace ProductManagement_.Features.Respositories.Interface
{
    public interface IUserRepository : IGenericRepository<UserAccount>
    {
        Task<UserAccount?> GetByUsernameAsync(string username);
    }
}
