using DemoGenericRepositoryPattern.Models;

namespace DemoGenericRepositoryPattern.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<Product> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task AddAsync(Product product, CancellationToken cancellationToken);
        Task UpdateAsync(Product product, CancellationToken cancellationToken);
        Task DeleteAsync(string id, CancellationToken cancellationToken);
    }
}
