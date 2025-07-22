using Abcloudz.Models.Interfaces;

namespace Abcloudz.DAL.Interfaces
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class, IBaseEntity<TKey>
    {
        Task<TEntity?> GetByIdAsync(TKey id, CancellationToken ct = default);
        Task<List<TEntity>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(TEntity entity, CancellationToken ct = default);
        Task UpdateAsync(TEntity entity, CancellationToken ct = default);
        Task DeleteAsync(TKey id, CancellationToken ct = default);
    }
}
