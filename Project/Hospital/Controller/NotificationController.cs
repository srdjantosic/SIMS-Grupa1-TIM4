using Project.Hospital.Model;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Controller
{
    public class NotificationController
    {
        private NotificationService notificationService;

        public NotificationController(NotificationService notificationService)
        {
            this.notificationService = notificationService; 
        }

        public Notification Create(Notification newNotification)
        {
            return notificationService.Create(newNotification);
        }

        public List<Notification> GetAllByReceiver(string lks)
        {
            return notificationService.GetAllByReceiver(lks);
        }

    }
}
