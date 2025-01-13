using DemoGenericRepositoryPattern.Data;

// generic repository for CRUD 

namespace DemoGenericRepositoryPattern.Repositories
{
    public abstract class Repository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext DbContext;
        protected Repository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            DbContext.Set<TEntity>().Add(entity);
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            DbContext.Set<TEntity>().Update(entity);
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var model = await DbContext.FindAsync<TEntity>(id, cancellationToken);
            return model!;
        }
        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var model = await DbContext.FindAsync<TEntity>(id, cancellationToken);
            DbContext.Set<TEntity>().Remove(model!);
            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
