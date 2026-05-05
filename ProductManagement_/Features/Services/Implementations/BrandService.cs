using ProductManagement_.Features.Data.Models;
using ProductManagement_.Features.Respositories.Interface;
using ProductManagement_.Features.Services.Interface;

namespace ProductManagement_.Features.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repo;

        public BrandService(IBrandRepository repo) => _repo = repo;

        public Task<List<Brand>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Brand?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);

        public async Task AddAsync(Brand brand)
        {
            var existing = await _repo.GetByNameAsync(brand.Name);
            if (existing != null)
                throw new Exception($"Brand '{brand.Name}' already exists.");
            brand.CreatedAt = DateTime.UtcNow;
            await _repo.AddAsync(brand);
        }

        public Task UpdateAsync(Brand brand) => _repo.UpdateAsync(brand);
    }
}
