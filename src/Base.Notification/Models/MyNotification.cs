using MediatR;

namespace Util.Notification.Models
{
    public class MyNotification : INotification
    {
        public MyNotification(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; private set; }

        public string Value { get; private set; }
    }
}
