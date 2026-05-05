using ProductManagement_.Features.Data.Models;

namespace ProductManagement_.Features.Services.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetAllWithDetailsAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> GetByIdWithDetailsAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
        Task<List<Product>> SearchAsync(string keyword);
        Task<List<Product>> GetByCategoryAsync(int categoryId);
        Task<List<Product>> GetByBrandAsync(int brandId);
        Task<List<Product>> GetBySupplierAsync(int supplierId);
    }
}
