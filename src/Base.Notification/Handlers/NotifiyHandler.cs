using MediatR;
using Util.Notification.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Util.Notification.Handlers
{
    public class NotifiyHandler : INotificationHandler<MyNotification>
    {
        private readonly IList<MyNotification> _notifications;

        public NotifiyHandler()
        {
            _notifications = new List<MyNotification>();
        }

        public Task Handle(MyNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);

            return Task.CompletedTask;
        }

        public virtual IEnumerable<MyNotification> GetNotifications()
        {
            return _notifications.Where(n => n.GetType() == typeof(MyNotification));
        }

        public virtual bool HasNotifications()
        {
            return _notifications.Any();
        }
    }
}
