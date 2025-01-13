using DemoGenericRepositoryPattern.Models;

namespace DemoGenericRepositoryPattern.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetListAsync(CancellationToken cancellationToken);
        Task<Category> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task AddAsync(Category category, CancellationToken cancellationToken);
        Task UpdateAsync(Category category, CancellationToken cancellationToken);
        Task DeleteAsync(string id, CancellationToken cancellationToken);
    }
}
