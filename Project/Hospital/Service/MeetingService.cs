using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.Repository;

namespace Project.Hospital.Service
{
    public class MeetingService
    {
        private MeetingRepository meetingRepository;
        private DoctorService doctorService;
        private NotificationService notificationService;

        public MeetingService(MeetingRepository meetingRepository, DoctorService doctorService, NotificationService notificationService)
        {
            this.meetingRepository = meetingRepository;
            this.doctorService = doctorService;
            this.notificationService = notificationService;
        }
        public Meeting Create(Meeting newMeeting)
        {
            return meetingRepository.Create(newMeeting);
        }
        public List<Meeting> GetAll()
        {
            return meetingRepository.GetAll();
        }
        public Meeting GetOne(int id)
        {
            return meetingRepository.GetOne(id);
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
