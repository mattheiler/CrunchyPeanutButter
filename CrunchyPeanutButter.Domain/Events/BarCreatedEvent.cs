using CrunchyPeanutButter.Domain.Aggregates.Bars;
using MediatR;

namespace CrunchyPeanutButter.Domain.Events
{
    public class BarCreatedEvent : INotification
    {
        public BarCreatedEvent(Bar bar)
        {
            Bar = bar;
        }

        public Bar Bar { get; }
    }
}