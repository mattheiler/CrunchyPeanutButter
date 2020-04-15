using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CrispyBacon.Stores.EntityFrameworkCore
{
    public abstract class EntityFrameworkCoreUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly ConcurrentDictionary<Type, object> _repositories = new ConcurrentDictionary<Type, object>();

        protected EntityFrameworkCoreUnitOfWork(TContext context)
        {
            Context = context;
        }

        protected TContext Context { get; }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public ValueTask DisposeAsync()
        {
            return Context.DisposeAsync();
        }

        protected IRepository<TAggregate> GetRepository<TAggregate>(Func<IRepository<TAggregate>> factory)
            where TAggregate : class
        {
            return (IRepository<TAggregate>) _repositories.GetOrAdd(typeof(TAggregate), _ => factory());
        }
    }
}