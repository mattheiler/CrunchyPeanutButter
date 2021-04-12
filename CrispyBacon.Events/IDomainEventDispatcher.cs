using System.Threading;
using System.Threading.Tasks;

namespace CrispyBacon.Events
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IDomainEvent;
    }
}