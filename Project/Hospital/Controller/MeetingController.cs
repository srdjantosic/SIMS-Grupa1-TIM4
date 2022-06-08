using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Service;
using Project.Hospital.Model;

namespace Project.Hospital.Controller
{
    public class MeetingController
    {
        private MeetingService meetingService;
        public MeetingController(MeetingService meetingService)
        {
            this.meetingService = meetingService;
        }
        public List<Meeting> GetAll()
        {
            return meetingService.GetAll();
        }
        public Meeting GetOne(int id)
        {
            return meetingService.GetOne(id);
        }
        public void ScheduleMeeting(Meeting newMeeting)
        {
            meetingService.ScheduleMeeting(newMeeting);
        }
    }
}
