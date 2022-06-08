using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Repository.IRepository
{
    public interface INotificationRepository
    {
        public Notification Create(Notification newNotification);
        public List<Notification> GetAll();
    }
}
