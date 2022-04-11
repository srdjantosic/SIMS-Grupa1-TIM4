/***********************************************************************
 * Module:  Prostorija.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Prostorija
 ***********************************************************************/

using System;


namespace Hospital.Model
{
   public class Room : Serializable
   {
      public String Name { get; set; }
      public RoomType Type { get; set; }
        public Boolean IsDeleted { get; set; } = false;

        public void fromCSV(string[] values)
        {
           
            
            Name = values[0];
            Type = RoomType.Parse(values[1]);
            IsDeleted = Boolean.Parse(values[2]);
            
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Name,
                Type.ToString(),
                IsDeleted.ToString()
            };
            return csvValues;
        }

    }
}