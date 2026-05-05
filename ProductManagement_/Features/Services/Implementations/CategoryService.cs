using ProductManagement_.Features.Data.Models;
using ProductManagement_.Features.Respositories.Interface;
using ProductManagement_.Features.Services.Interface;

namespace ProductManagement_.Features.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo) => _repo = repo;

        public Task<List<Category>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Category?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);

        public async Task AddAsync(Category category)
        {
            var existing = await _repo.GetByNameAsync(category.Name);
            if (existing != null)
                throw new Exception($"Category '{category.Name}' already exists.");
            category.CreatedAt = DateTime.UtcNow;
            await _repo.AddAsync(category);
        }

        public Task UpdateAsync(Category category) => _repo.UpdateAsync(category);

    }
}
