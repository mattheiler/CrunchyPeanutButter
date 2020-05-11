using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;

namespace CrispyBacon.Stores.AwsDynamoDb
{
    public class DynamoDbContext : IAsyncDisposable, IDisposable
    {
        private readonly IDynamoDBContext _context;

        private readonly IAmazonDynamoDB _client;

        private readonly ConcurrentBag<TransactWriteItem> _writes = new ConcurrentBag<TransactWriteItem>();

        private bool _disposed;

        public DynamoDbContext(IDynamoDBContext context, IAmazonDynamoDB client)
        {
            _context = context;
            _client = client;
        }

        public ValueTask DisposeAsync()
        {
            Dispose();
            return default;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DynamoDbContext()
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

        public void Add<T>(T entity)
        {
            var table = _context.GetTargetTable<T>();
            var document = _context.ToDocument(entity);
            var attributes = table.ToAttributeMap(document);

            _writes.Add(new TransactWriteItem
            {
                Put = new Put
                {
                    TableName = table.TableName,
                    Item = attributes
                }
            });
        }

        public void Update<T>(T entity)
        {
            var table = _context.GetTargetTable<T>();
            var document = _context.ToDocument(entity);
            var attributes = table.ToAttributeMap(document);

            _writes.Add(new TransactWriteItem
            {
                Update = new Update
                {
                    TableName = table.TableName,
                    Key = table.Keys.ToDictionary(entry => entry.Key, entry => attributes[entry.Key]),
                    UpdateExpression = $"SET {string.Join(", ", document.ToAttributeUpdateMap(true).Select(entry => UpdateExpression(entry.Key, document[entry.Key], entry.Value)))}"
                }
            });
        }

        private string UpdateExpression(string key, DynamoDBEntry value, AttributeValueUpdate metadata)
        {
            // https://docs.aws.amazon.com/amazondynamodb/latest/APIReference/API_AttributeValueUpdate.html

            switch (metadata.Action)
            {
                case "ADD":
                    throw new NotImplementedException();
                case "DELETE":
                    throw new NotImplementedException();
                case "PUT":
                    throw new NotImplementedException();
                default:
                    throw new NotSupportedException(metadata.Action);
            }
        }

        public void Remove<T>(T entity)
        {
            var table = _context.GetTargetTable<T>();
            var document = _context.ToDocument(entity);
            var attributes = table.ToAttributeMap(document);

            _writes.Add(new TransactWriteItem
            {
                Delete = new Delete
                {
                    TableName = table.TableName,
                    Key = table.Keys.ToDictionary(entry => entry.Key, entry => attributes[entry.Key]),
                }
            });
        }

        public Task<T> FindAsync<T>(object[] key, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<T> WhereAsync<T>(Expression<Func<T, bool>> query, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync<T>(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync<T>(Expression<Func<T, bool>> query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            var request = new TransactWriteItemsRequest
            {
                TransactItems = _writes.ToList()
            };

            await _client.TransactWriteItemsAsync(request, cancellationToken);

            _writes.Clear();
        }
    }
}