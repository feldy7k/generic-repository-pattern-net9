using DemoGenericRepositoryPattern.Data;
using DemoGenericRepositoryPattern.Interfaces;
using DemoGenericRepositoryPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoGenericRepositoryPattern.Repositories
{
    // CategoryRepository.cs
    public class CategoryRepository(AppDbContext _context) : Repository<Category>(_context), ICategoryRepository
    {
        public async Task<IEnumerable<Category>> GetListAsync(CancellationToken cancellationToken)
        {
            return await DbContext.Categories.ToListAsync(cancellationToken);
        }
    }

}
