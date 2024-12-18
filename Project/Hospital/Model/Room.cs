using System;

namespace Project.Hospital.Model
{
    public class Room : Serializable
    {
        public String Name { get; set; }
        public RoomType.RoomTypes Type { get; set; }
        public Boolean IsDeleted { get; set; } = false;

        public Room() { }
        public Room(String Name, RoomType.RoomTypes Type)
        {
            this.Name = Name;
            this.Type = Type;
        }

        public void fromCSV(string[] values)
        {


            Name = values[0];
            Type = (RoomType.RoomTypes)Enum.Parse(typeof(RoomType.RoomTypes), values[1]);
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