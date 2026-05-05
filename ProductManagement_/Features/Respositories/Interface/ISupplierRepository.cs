using ProductManagement_.Features.Data.Models;

namespace ProductManagement_.Features.Respositories.Interface
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        Task<Supplier?> GetByNameAsync(string name);
    }
}
