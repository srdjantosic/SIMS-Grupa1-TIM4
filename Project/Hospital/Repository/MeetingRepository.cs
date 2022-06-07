using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Repository
{
    public class MeetingRepository
    {
        private const string fileName = "meetings.txt";
        public MeetingRepository() { }
        public Meeting Create(Meeting newMeeting)
        {
            Serializer<Meeting> meetingSerializer = new Serializer<Meeting>();
            meetingSerializer.oneToCSV(fileName, newMeeting);
            return newMeeting;
        }
        public List<Meeting> GetAll()
        {
            Serializer<Meeting> meetingSerializer = new Serializer<Meeting>();
            return meetingSerializer.fromCSV(fileName);
        }
        public Meeting GetOne(int id)
        {
            return GetAll().SingleOrDefault(meeting => meeting.Id == id);
        }
    }
}
