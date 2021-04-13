using CrunchyPeanutButter.Domain.Abstractions.Events;
using CrunchyPeanutButter.Domain.Models.Bars;

namespace CrunchyPeanutButter.Domain.Events.Bars
{
    public class BarCreatedEvent : IDomainEvent
    {
        public BarCreatedEvent(Bar bar)
        {
            Bar = bar;
        }

        public Bar Bar { get; }

        public string Name { get; } = nameof(BarCreatedEvent);
    }
}