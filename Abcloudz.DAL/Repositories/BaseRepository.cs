using Abcloudz.DAL.Interfaces;
using Abcloudz.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Abcloudz.DAL.Repositories
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class, IBaseEntity<TKey>
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, ct);
        }

        public async Task<List<TEntity>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbSet
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task AddAsync(TEntity entity, CancellationToken ct = default)
        {
            await _dbSet.AddAsync(entity, ct);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken ct = default)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TKey id, CancellationToken ct = default)
        {
            var entity = await GetByIdAsync(id, ct);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
            await _dbContext.SaveChangesAsync();
        }
    }

}
