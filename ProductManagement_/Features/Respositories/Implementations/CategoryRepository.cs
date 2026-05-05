using Microsoft.EntityFrameworkCore;
using ProductManagement_.Features.Data;
using ProductManagement_.Features.Data.Models;
using ProductManagement_.Features.Respositories.Interface;

namespace ProductManagement_.Features.Respositories.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }
        public async Task<Category?> GetByNameAsync(string name) =>
            await _dbSet.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        
    }
}
