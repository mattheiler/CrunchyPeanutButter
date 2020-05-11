using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CrispyBacon.Stores.AwsDynamoDb
{
    public class DynamoDbRepository<T> : IRepository<T> where T : class
    {
        private readonly DynamoDbContext _context;

        public DynamoDbRepository(DynamoDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            Add(entity);
            return Task.CompletedTask;
        }

        public void AddRange(T[] entities)
        {
            foreach(var entity in entities)
                Add(entity);
        }

        public async Task AddRangeAsync(T[] entities, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
                await AddAsync(entity, cancellationToken);
        }

        public Task<T> FindAsync(params object[] keys)
        {
            return _context.FindAsync<T>(keys);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void UpdateRange(T[] entities)
        {
            foreach (var entity in entities)
                Update(entity);
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
        }

        public void RemoveRange(T[] entities)
        {
            foreach (var entity in entities)
                Remove(entity);
        }
    }
}