using Microsoft.EntityFrameworkCore;
using ProductManagement_.Features.Data;
using ProductManagement_.Features.Data.Models;
using ProductManagement_.Features.Respositories.Interface;

namespace ProductManagement_.Features.Respositories.Implementations
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AppDbContext context) : base(context) { }
        public async Task<Supplier?> GetByNameAsync(string name) =>
            await _dbSet.FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower());
        
    }
}
