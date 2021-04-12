using CustomerApiWithService.Application.Notifications;
using System.Collections.Generic;

namespace CustomerApiWithService.Application.Interfaces
{
    public interface INotificationContext
    {
        void AddNotification(string message);

        void AddNotification(Notification notification);

        void AddNotifications(IList<Notification> notifications);
    }
}
