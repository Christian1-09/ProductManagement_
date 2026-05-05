using Microsoft.EntityFrameworkCore;
using ProductManagement_.Features.Data;
using ProductManagement_.Features.Data.Models;
using ProductManagement_.Features.Respositories.Interface;

namespace ProductManagement_.Features.Respositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }
        public async Task<List<Product>> GetAllWithDetailsAsync() =>
           await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Supplier)
                .ToListAsync();
        public async Task<Product?> GetByIdWithDetailsAsync(int id) =>
            await _dbSet
                 .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.Id == id);
        public async Task<List<Product>> GetByCategoryAsync(int categoryId) =>
            await _dbSet
                 .Include(p => p.Brand)
                .Include(p => p.Supplier)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();

        public async Task<List<Product>> GetByBrandAsync(int brandId) =>
            await _dbSet
                 .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Where(p => p.BrandId == brandId)
                .ToListAsync();

        public async Task<List<Product>> GetBySupplierAsync(int supplierId) =>
            await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(p => p.SupplierId == supplierId)
                .ToListAsync();

        public async Task<List<Product>> SearchAsync(string keyword) =>
            await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Supplier)
                .Where(p => p.Name.Contains(keyword) ||
                            (p.Description != null && p.Description.Contains(keyword)) ||
                            (p.SKU != null && p.SKU.Contains(keyword)))
                .ToListAsync();

    }
}
