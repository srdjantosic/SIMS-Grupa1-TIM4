using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Repository.IRepository;

namespace Project.Hospital.Service
{
    public class MeetingService
    {
        private IMeetingRepository iMeetingRepo;
        private DoctorService doctorService;
        private NotificationService notificationService;

        public MeetingService(IMeetingRepository iMeetingRepo, DoctorService doctorService, NotificationService notificationService)
        {
            this.iMeetingRepo = iMeetingRepo;
            this.doctorService = doctorService;
            this.notificationService = notificationService;
        }
        public Meeting Create(Meeting newMeeting)
        {
            return iMeetingRepo.Create(newMeeting);
        }
        public List<Meeting> GetAll()
        {
            return iMeetingRepo.GetAll();
        }
        public Meeting GetOne(int id)
        {
            return iMeetingRepo.GetOne(id);
        }
        public void ScheduleMeeting(Meeting newMeeting)
        {
            if (Create(newMeeting) != null)
            {
                foreach(string participant in newMeeting.Participants)
                {
                    Notification newNotification = new Notification(participant, DateTime.Now, "Sastanak zakazan za " + newMeeting.MaintenanceTime.ToString());
                    notificationService.Create(newNotification);
                }
            }
        }
    }
}
