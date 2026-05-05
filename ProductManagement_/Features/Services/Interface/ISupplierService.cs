using ProductManagement_.Features.Data.Models;

namespace ProductManagement_.Features.Services.Interface
{
    public interface ISupplierService
    {
        Task<List<Supplier>> GetAllAsync();
        Task<Supplier?> GetByIdAsync(int id);
        Task AddAsync(Supplier supplier);
        Task UpdateAsync(Supplier supplier);
        Task DeleteAsync(int id);
    }
}
