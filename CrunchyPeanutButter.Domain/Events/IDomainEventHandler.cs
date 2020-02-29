using MediatR;

namespace CrunchyPeanutButter.Domain.Events
{
    public interface IDomainEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IDomainEvent
    {
    }
}