using ProductManagement_.Features.Data.Models;

namespace ProductManagement_.Features.Respositories.Interface
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetAllWithDetailsAsync();
        Task<Product?> GetByIdWithDetailsAsync(int id);
        Task<List<Product>> GetByCategoryAsync(int categoryId);
        Task<List<Product>> GetByBrandAsync(int brandId);
        Task<List<Product>> GetBySupplierAsync(int supplierId);
        Task<List<Product>> SearchAsync(string keyword);
    }
}
