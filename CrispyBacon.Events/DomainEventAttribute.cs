using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrispyBacon.Events
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DomainEventAttribute : Attribute
    {
        public DomainEventAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public interface IEvent
    {
        string Name { get; }
    }

    public interface IEventDispatcher
    {
        Task DispatchAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IEvent;
    }
}