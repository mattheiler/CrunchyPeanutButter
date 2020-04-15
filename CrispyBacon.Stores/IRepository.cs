using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CrispyBacon.Stores
{
    public interface IRepository<TEntity> : IQueryable<TEntity>, IAsyncEnumerable<TEntity>
    {
        public void Add(TEntity entity);

        public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        public void AddRange(TEntity[] entities);

        public Task AddRangeAsync(TEntity[] entities, CancellationToken cancellationToken = default);

        Task<TEntity> FindAsync(params object[] keys);

        public void Update(TEntity entity);

        public void UpdateRange(TEntity[] entities);

        public void Remove(TEntity entity);

        public void RemoveRange(TEntity[] entities);
    }
}