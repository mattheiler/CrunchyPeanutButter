using MediatR;

namespace CrunchyPeanutButter.Domain.Messages
{
    public interface IDomainMessageHandler<in TMessage> : INotificationHandler<TMessage> where TMessage : IDomainMessage
    {
    }
}