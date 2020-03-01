using MediatR;

namespace CrispyBacon.Events
{
    public interface IDomainEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IDomainEvent
    {
    }
}