using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Model
{
    public class Meeting :Serializable
    {
        public int Id { get; set; }
        public String Room { get; set; }
        public DateTime MaintenanceTime { get; set; }
        public List<String> Participants { get; set; }
        public Meeting() { }
        public Meeting(int id, String room, DateTime maintenanceTime, List<String> participants)
        {
            this.Id = id;
            this.Room = room;
            this.MaintenanceTime = maintenanceTime;
            this.Participants = participants;
        }
        public void fromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Room = values[1];
            MaintenanceTime = DateTime.Parse(values[2]);
            
            List<string> participants = values[3].Split(',').ToList();
            foreach (string participant in participants)
            {
                Participants.Add(participant);
            }
        }

        public string[] toCSV()
        {
            List<string> participants = new List<string>();
            foreach (string participant in Participants)
            {
                participants.Add(participant);
            }
 
            string[] csvValues =
            {
            Id.ToString(),
            Room,
            MaintenanceTime.ToString(),
            string.Join(',', participants)
            };
            return csvValues;
        }

    }
}
