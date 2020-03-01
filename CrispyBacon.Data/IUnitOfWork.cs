using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrispyBacon.Data
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IAggregateRoot;

        void Save();

        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}