using Project.Hospital.Model;
using Project.Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Service
{
    public class NotificationService
    {

        private NotificationRepository notificationRepository;
        private const string NOT_FOUND_ERROR = "Notification with {0}:{1} can not be found!";

        public NotificationService(NotificationRepository notificationRepository)
        {
            this.notificationRepository = notificationRepository;
        }

        public Notification Create(Notification newNotification)
        {
            return notificationRepository.Create(newNotification);
        }

        public List<Notification> GetAll()
        {
            return notificationRepository.GetAll();
        }

        public List<Notification> GetAllByReceiver(string lks)
        {
            List<Notification> notifications = new List<Notification>();
            foreach(Notification notification in GetAll())
            {
                if (notification.Receiver.Equals(lks))
                {
                    notifications.Add(notification);
                }
            }
            return notifications;
        }
    }
}
