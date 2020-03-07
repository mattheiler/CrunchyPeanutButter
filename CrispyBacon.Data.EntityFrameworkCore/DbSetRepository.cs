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
    public class DbSetRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        public DbSetRepository(DbSet<TEntity> set)
        {
            Set = set;
        }

        protected DbSet<TEntity> Set { get; }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return Set.AsQueryable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType => Set.AsQueryable().ElementType;

        public Expression Expression => Set.AsQueryable().Expression;

        public IQueryProvider Provider => Set.AsQueryable().Provider;

        public IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return Set.AsAsyncEnumerable().GetAsyncEnumerator(cancellationToken);
        }

        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Set.AddAsync(entity, cancellationToken);
        }

        public void AddRange(TEntity[] entities)
        {
            Set.AddRange(entities);
        }

        public Task AddRangeAsync(TEntity[] entities, CancellationToken cancellationToken = default)
        {
            return Set.AddRangeAsync(entities, cancellationToken);
        }

        public async Task<TEntity> FindAsync(params object[] keys)
        {
            return await Set.FindAsync(keys);
        }

        public void Update(TEntity entity)
        {
            Set.Update(entity);
        }

        public void UpdateRange(TEntity[] entities)
        {
            Set.UpdateRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Set.Remove(entity);
        }

        public void RemoveRange(TEntity[] entities)
        {
            Set.RemoveRange(entities);
        }
    }
}