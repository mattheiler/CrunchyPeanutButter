using System;
using MediatR;

namespace CrunchyPeanutButter.Core.Events.Bars
{
    public class BarCreatedEvent : INotification
    {
        public BarCreatedEvent(Guid barId)
        {
            BarId = barId;
        }

        public Guid BarId { get; }
    }
}