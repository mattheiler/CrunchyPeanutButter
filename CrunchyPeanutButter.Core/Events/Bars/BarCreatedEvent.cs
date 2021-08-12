using CrunchyPeanutButter.Core.Models.Bars;
using MediatR;

namespace CrunchyPeanutButter.Core.Events.Bars
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