using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Repository
{
    public class NotificationRepository
    {
        private const string NOT_FOUND_ERROR = "Notification with {0}:{1} can not be found!";
        private const string fileName = "notification.txt";

        public Notification Create(Notification newNotification)
        {
            Serializer<Notification> notificationSerializer = new Serializer<Notification>();
            Notification notification = new Notification(newNotification.Lks, newNotification.CreationDate, newNotification.Message, newNotification.Lbo);
            notificationSerializer.oneToCSV(fileName, notification);
            return notification;
        }

        public List<Notification> GetAll()
        {
            Serializer<Notification> notificationSerializer = new Serializer<Notification>();
            List<Notification> notifications = notificationSerializer.fromCSV(fileName);
            return notifications;
        }

    }
}
