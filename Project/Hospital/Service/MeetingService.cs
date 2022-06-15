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
        private ScheduleMeetingService scheduleMeetingService;
        private NotificationService notificationService;

        public MeetingService(IMeetingRepository iMeetingRepo, ScheduleMeetingService scheduleMeetingService, NotificationService notificationService)
        {
            this.iMeetingRepo = iMeetingRepo;
            this.scheduleMeetingService = scheduleMeetingService;
            this.notificationService = notificationService;
        }
        public MeetingService(IMeetingRepository iMeetingRepo)
        {
            this.iMeetingRepo = iMeetingRepo;
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
        public List<Meeting> GetAllByRoom(String roomName)
        {
            List<Meeting> meetings = new List<Meeting>();
            foreach(Meeting meeting in GetAll())
            {
                if(meeting.Room == roomName)
                {
                    meetings.Add(meeting);
                }
            }
            return meetings;
        }
        public List<Meeting> GetAllByParticipant(String designation)
        {
            List<Meeting> meetings = new List<Meeting>();
            foreach(Meeting meeting in GetAll())
            {
                foreach(String participant in meeting.Participants)
                {
                    if(participant == designation)
                    {
                        meetings.Add(meeting);
                    }
                }
            }
            return meetings;
        }
        public Meeting ScheduleMeeting(Meeting newMeeting)
        {
            if (scheduleMeetingService.isRoomFreeInSelectedTime(newMeeting.Room, newMeeting.MaintenanceTime) && scheduleMeetingService.areParticipantsFree(newMeeting))
            {
                Meeting scheduledMeeting = Create(newMeeting);
                foreach(string participant in newMeeting.Participants)
                {
                    Notification newNotification = new Notification(participant, DateTime.Now, "Sastanak zakazan za " + scheduledMeeting.MaintenanceTime.ToString());
                    notificationService.Create(newNotification);
                }
                return scheduledMeeting;
            }
            return null;
        }
    }
}
