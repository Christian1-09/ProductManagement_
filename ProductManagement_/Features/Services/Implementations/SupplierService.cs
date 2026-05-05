using ProductManagement_.Features.Data.Models;
using ProductManagement_.Features.Respositories.Interface;
using ProductManagement_.Features.Services.Interface;

namespace ProductManagement_.Features.Services.Implementations
{
    public class SupplierService :ISupplierService
    {
        private readonly ISupplierRepository _repo;

        public SupplierService(ISupplierRepository repo) => _repo = repo;

        public Task<List<Supplier>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Supplier?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);

        public async Task AddAsync(Supplier supplier)
        {
            var existing = await _repo.GetByNameAsync(supplier.Name);
            if (existing != null)
                throw new Exception($"Supplier '{supplier.Name}' already exists.");
            supplier.CreatedAt = DateTime.UtcNow;
            await _repo.AddAsync(supplier);
        }

        public Task UpdateAsync(Supplier supplier) => _repo.UpdateAsync(supplier);
    }
}
