using MediatR;

namespace CrunchyPeanutButter.Domain.Notifications
{
    public interface IDomainNotificationHandler<in TNotification> : INotificationHandler<TNotification> where TNotification : IDomainNotification
    {
    }
}