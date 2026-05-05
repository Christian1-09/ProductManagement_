using ProductManagement_.Features.Data.Models;

namespace ProductManagement_.Features.Respositories.Interface
{
    public interface IBrandRepository :IGenericRepository<Brand>
    {
        Task<Brand?>GetByNameAsync(string name);
    }
}
