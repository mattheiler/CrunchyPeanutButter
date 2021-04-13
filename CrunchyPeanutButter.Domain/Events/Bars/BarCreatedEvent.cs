using CrunchyPeanutButter.Domain.Models.Bars;
using MediatR;

namespace CrunchyPeanutButter.Domain.Events.Bars
{
    public class BarCreatedEvent : INotification
    {
        public BarCreatedEvent(Bar bar)
        {
            Bar = bar;
        }

        public Bar Bar { get; }

        public string Name { get; } = nameof(BarCreatedEvent);
    }
}