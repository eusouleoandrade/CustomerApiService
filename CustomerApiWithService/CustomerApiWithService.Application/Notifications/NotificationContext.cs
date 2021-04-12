using CustomerApiWithService.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CustomerApiWithService.Application.Notifications
{
    public class NotificationContext : INotificationContext
    {
        // Fields
        private readonly List<Notification> _notifications;

        // Properties
        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public bool HasNotifications => _notifications.Any();

        // Ctros
        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }

        // Methods
        public void AddNotification(string message)
        {
            _notifications.Add(new Notification(message));
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotifications(IList<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }
    }
}
