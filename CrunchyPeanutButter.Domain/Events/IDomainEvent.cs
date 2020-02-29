using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CrunchyPeanutButter.Domain.Events
{
    public interface IDomainEvent : INotification
    {
    }
}
