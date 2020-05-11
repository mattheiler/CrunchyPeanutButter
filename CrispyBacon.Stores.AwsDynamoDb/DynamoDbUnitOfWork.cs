using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrispyBacon.Stores.AwsDynamoDb
{
    public class DynamoDbUnitOfWork<TContext> : IUnitOfWork
        where TContext : DynamoDbContext
    {
        private readonly TContext _context;

        private bool _disposed;

        public DynamoDbUnitOfWork(TContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ValueTask DisposeAsync()
        {
            Dispose();
            return default;
        }

        public Task SaveAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveAsync(cancellationToken);
        }

        ~DynamoDbUnitOfWork()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _context.Dispose();

            _disposed = true;
        }
    }
}