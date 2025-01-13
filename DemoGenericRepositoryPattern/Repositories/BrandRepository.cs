using DemoGenericRepositoryPattern.Data;
using DemoGenericRepositoryPattern.Interfaces;
using DemoGenericRepositoryPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoGenericRepositoryPattern.Repositories
{
    // BrandRepository
    public class BrandRepository(AppDbContext _context) :Repository<Brand>(_context), IBrandRepository
    {
        public async Task<IEnumerable<Brand>> GetListAsync(CancellationToken cancellationToken)
        {
            return await DbContext.Brands.ToListAsync(cancellationToken);
        }
    }

}
