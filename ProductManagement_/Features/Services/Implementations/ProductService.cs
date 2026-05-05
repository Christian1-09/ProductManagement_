using ProductManagement_.Features.Data.Models;
using ProductManagement_.Features.Respositories.Interface;
using ProductManagement_.Features.Services.Interface;

namespace ProductManagement_.Features.Services.Implementations
{

    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo) => _repo = repo;

        public Task<List<Product>> GetAllAsync() => _repo.GetAllAsync();
        public Task<List<Product>> GetAllWithDetailsAsync() => _repo.GetAllWithDetailsAsync();
        public Task<Product?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Product?> GetByIdWithDetailsAsync(int id) => _repo.GetByIdWithDetailsAsync(id);
        public Task<List<Product>> SearchAsync(string kw) => _repo.SearchAsync(kw);
        public Task<List<Product>> GetByCategoryAsync(int id) => _repo.GetByCategoryAsync(id);
        public Task<List<Product>> GetByBrandAsync(int id) => _repo.GetByBrandAsync(id);
        public Task<List<Product>> GetBySupplierAsync(int id) => _repo.GetBySupplierAsync(id);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);

        public async Task AddAsync(Product product)
        {
            product.CreatedAt = DateTime.UtcNow;
            await _repo.AddAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            product.UpdatedAt = DateTime.UtcNow;
            await _repo.UpdateAsync(product);
        }
    }
}
