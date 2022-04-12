/***********************************************************************
 * Module:  Appointment.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Model.Appointment
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Appointment : Serializable
    {
        public int Id { get; set; }
        public String Lks { get; set; }
        public System.DateTime DateTime { get; set; } // Month/Day/Year H[:M:S] [AM|PM]
        public String Lbo { get; set; }
        

        public Appointment () {}

        public Appointment(int id, string lks, DateTime dateTime, string lbo)
        {
            Id = id;
            Lks = lks;
            DateTime = dateTime;
            Lbo = lbo;
        }

        public void fromCSV(string[] values)
        {
             Id = int.Parse(values[0]);
             Lks = values[1];
             DateTime = System.DateTime.Parse(values[2]);
             Lbo = values[3];
    }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Lks,
                DateTime.ToString(),
                Lbo
            };
            return csvValues;
        }

    }
}