using System;

namespace Hospital.Model
{
    public class Appointment : Serializable
    {
        public int Id { get; set; }
        public String Lks { get; set; }
        public DateTime _DateTime { get; set; } // Month/Day/Year H[:M:S] [AM|PM] H->8-12 AM|PM
        public String Lbo { get; set; }

        public Boolean IsDeleted { get; set; } = false;
        

        public Appointment () {}

        public Appointment(int id, string lks, DateTime dateTime, string lbo)
        {
            Id = id;
            Lks = lks;
            _DateTime = dateTime;
            Lbo = lbo;
        }

        public void fromCSV(string[] values)
        {
             Id = int.Parse(values[0]);
             Lks = values[1];
            _DateTime = DateTime.Parse(values[2]);
             Lbo = values[3];
             IsDeleted = Boolean.Parse(values[4]);
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Lks,
                _DateTime.ToString(),
                Lbo,
                IsDeleted.ToString()
            };
            return csvValues;
        }

    }
}