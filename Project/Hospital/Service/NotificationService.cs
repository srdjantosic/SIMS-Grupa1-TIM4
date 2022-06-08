using Project.Hospital.Model;
using Project.Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Repository.IRepository;

namespace Project.Hospital.Service
{
    public class NotificationService
    {

        private INotificationRepository iNotificationRepo;
        private const string NOT_FOUND_ERROR = "Notification with {0}:{1} can not be found!";

        public NotificationService(INotificationRepository iNotificationRepo)
        {
            this.iNotificationRepo = iNotificationRepo;
        }

        public Notification Create(Notification newNotification)
        {
            return iNotificationRepo.Create(newNotification);
        }

        public List<Notification> GetAll()
        {
            return iNotificationRepo.GetAll();
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
