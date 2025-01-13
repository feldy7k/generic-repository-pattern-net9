using DemoGenericRepositoryPattern.Data;
using DemoGenericRepositoryPattern.Interfaces;
using DemoGenericRepositoryPattern.Models;
using Microsoft.EntityFrameworkCore;
namespace DemoGenericRepositoryPattern.Repositories
{
    // ProductRepository
    public class ProductRepository(AppDbContext _context) : Repository<Product>(_context), IProductRepository
    {
        public async Task<IEnumerable<Product>> GetListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await DbContext.Products
                .Skip((pageNumber - 1) * pageSize) // Skip items from previous pages
                .Take(pageSize)  // Take items for the current page
                .ToListAsync(cancellationToken);
        }
    }

}
