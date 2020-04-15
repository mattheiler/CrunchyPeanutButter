using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrispyBacon.Stores
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        void Save();

        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}