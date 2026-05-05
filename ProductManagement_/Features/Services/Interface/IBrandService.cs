using ProductManagement_.Features.Data.Models;

namespace ProductManagement_.Features.Services.Interface
{
    public interface IBrandService
    {
        Task<List<Brand>> GetAllAsync();
        Task<Brand?> GetByIdAsync(int id);
        Task AddAsync(Brand brand);
        Task UpdateAsync(Brand brand);
        Task DeleteAsync(int id);
    }
}
