using System;

namespace Project.Hospital.Model
{
    public class Appointment : Serializable
    {
        public int Id { get; set; }
        public String Lks { get; set; }
        public DateTime dateTime { get; set; } // Month/Day/Year H[:M:S] [AM|PM] H->8-12 AM|PM
        public String Lbo { get; set; }

        public Boolean isDeleted { get; set; } = false;

        public String RoomName { get; set; }


        public Appointment() { }

        public Appointment(int Id, string Lks, DateTime dateTime, string Lbo, String RoomName)
        {
            this.Id = Id;
            this.Lks = Lks;
            this.dateTime = dateTime;
            this.Lbo = Lbo;
            this.RoomName = RoomName;
        }

        public void fromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Lks = values[1];
            dateTime = DateTime.Parse(values[2]);
            Lbo = values[3];
            isDeleted = Boolean.Parse(values[4]);
            RoomName = values[5];
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Lks,
                dateTime.ToString(),
                Lbo,
                isDeleted.ToString(),
                RoomName
            };
            return csvValues;
        }

    }
}