using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CrunchyPeanutButter.Domain.Messages
{
    public interface IDomainMessage : INotification
    {
    }
}
