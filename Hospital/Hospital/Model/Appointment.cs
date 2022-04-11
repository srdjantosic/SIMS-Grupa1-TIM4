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
      public int Lks;
      public System.DateTime DateTime;
      public int Lbo;
      public int Id;

        public void fromCSV(string[] values)
        {
             Lks = int.Parse(values[0]);
             DateTime = System.DateTime.Parse(values[1]);
             Lbo = int.Parse(values[2]);
             Id = int.Parse(values[3]);
    }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Lks.ToString(),
                DateTime.ToString(),
                Lbo.ToString(),
                Id.ToString()
            };
            return csvValues;
        }

    }
}