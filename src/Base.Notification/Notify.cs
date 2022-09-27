using MediatR;
using Util.Notification.Handlers;
using Util.Notification.Models;
using System.Threading;

namespace Util.Notification
{
    public class Notify : INotify
    {
        private readonly NotifiyHandler _messageHandler;

        public Notify(INotificationHandler<MyNotification> notification)
        {
            _messageHandler = (NotifiyHandler)notification;
        }

        public Notify Invoke()
        {
            return this;
        }

        public bool IsValid()
        {
            return !_messageHandler.HasNotifications();
        }

        public void Add(string key, string message)
        {
            _messageHandler.Handle(new MyNotification(key, message), default(CancellationToken));
        }
    }
}
