using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.Repository.IRepository;

namespace Project.Hospital.Repository
{
    public class MeetingRepository :IMeetingRepository
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
