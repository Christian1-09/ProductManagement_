using Microsoft.EntityFrameworkCore;
using ProductManagement_.Features.Data;
using ProductManagement_.Features.Data.Models;
using ProductManagement_.Features.Respositories.Interface;

namespace ProductManagement_.Features.Respositories.Implementations
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) : base(context) { }
        public async Task<Brand?> GetByNameAsync(string name) =>
            await _dbSet.FirstOrDefaultAsync(b => b.Name.ToLower() == name.ToLower());
        
    }
}
