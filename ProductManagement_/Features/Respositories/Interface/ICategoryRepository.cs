
using ProductManagement_.Features.Data.Models;

namespace ProductManagement_.Features.Respositories.Interface
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category?> GetByNameAsync(string name);
    }
}
