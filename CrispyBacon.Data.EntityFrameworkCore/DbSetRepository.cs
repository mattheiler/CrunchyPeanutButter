using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CrispyBacon.Data.EntityFrameworkCore
{
    public class DbSetRepository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        private readonly DbSet<TEntity> _set;

        public DbSetRepository(DbSet<TEntity> set)
        {
            _set = set;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _set.AsQueryable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType => _set.AsQueryable().ElementType;

        public Expression Expression => _set.AsQueryable().Expression;

        public IQueryProvider Provider => _set.AsQueryable().Provider;

        public IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return _set.AsAsyncEnumerable().GetAsyncEnumerator(cancellationToken);
        }

        public void Add(TEntity entity)
        {
            _set.Add(entity);
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _set.AddAsync(entity, cancellationToken);
        }

        public void AddRange(TEntity[] entities)
        {
            _set.AddRange(entities);
        }

        public Task AddRangeAsync(TEntity[] entities, CancellationToken cancellationToken = default)
        {
            return _set.AddRangeAsync(entities, cancellationToken);
        }

        public async Task<TEntity> FindAsync(params object[] keys)
        {
            return await _set.FindAsync(keys);
        }

        public void Update(TEntity entity)
        {
            _set.Update(entity);
        }

        public void UpdateRange(TEntity[] entities)
        {
            _set.UpdateRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _set.Remove(entity);
        }

        public void RemoveRange(TEntity[] entities)
        {
            _set.RemoveRange(entities);
        }
    }
}