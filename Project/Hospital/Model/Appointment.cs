using System;

namespace Project.Hospital.Model
{
    public class Appointment : Serializable
    {
        public int id { get; set; }
        public String lks { get; set; }
        public DateTime dateTime { get; set; } // Month/Day/Year H[:M:S] [AM|PM] H->8-12 AM|PM
        public String lbo { get; set; }

        public Boolean isDeleted { get; set; } = false;


        public Appointment() { }

        public Appointment(int id, string lks, DateTime dateTime, string lbo)
        {
            id = id;
            lks = lks;
            dateTime = dateTime;
            lbo = lbo;
        }

        public void fromCSV(string[] values)
        {
            id = int.Parse(values[0]);
            lks = values[1];
            dateTime = DateTime.Parse(values[2]);
            lbo = values[3];
            isDeleted = Boolean.Parse(values[4]);
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                id.ToString(),
                lks,
                dateTime.ToString(),
                lbo,
                isDeleted.ToString()
            };
            return csvValues;
        }

    }
}