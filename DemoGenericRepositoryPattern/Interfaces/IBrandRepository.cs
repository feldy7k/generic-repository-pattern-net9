
using DemoGenericRepositoryPattern.Models;

namespace DemoGenericRepositoryPattern.Interfaces
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetListAsync(CancellationToken cancellationToken);
        Task<Brand> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task AddAsync(Brand brand, CancellationToken cancellationToken);
        Task UpdateAsync(Brand brand, CancellationToken cancellationToken);
        Task DeleteAsync(string id, CancellationToken cancellationToken);
    }
}
