using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Repository.IRepository;

namespace Project.Hospital.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private const string NOT_FOUND_ERROR = "Notification with {0}:{1} can not be found!";
        private const string fileName = "notification.txt";

        public Notification Create(Notification newNotification)
        {
            Serializer<Notification> notificationSerializer = new Serializer<Notification>();
            notificationSerializer.oneToCSV(fileName, newNotification);
            return newNotification;
        }

        public List<Notification> GetAll()
        {
            Serializer<Notification> notificationSerializer = new Serializer<Notification>();
            return notificationSerializer.fromCSV(fileName);
        }

    }
}
