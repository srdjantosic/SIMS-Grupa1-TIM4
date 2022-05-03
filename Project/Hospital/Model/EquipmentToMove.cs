using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Model
{
    public class EquipmentToMove : Serializable
    {
        public String Name { get; set; }
        public int Quantity { get; set; }

        public String RoomId { get; set; }
        public String NewRoomId { get; set; }

        public String Id { get; set; }
        public DateTime dateTime { get; set; }
        public EquipmentToMove() { }
        public EquipmentToMove(String Id,String Name, String RoomId, String NewRoomId, int Quantity, DateTime datetime)
        {
            this.Id = Id;
            this.Name = Name;
            this.NewRoomId = NewRoomId;
            this.Quantity = Quantity;
            this.dateTime = datetime;
            this.RoomId = RoomId;
        }

        public void fromCSV(string[] values)
        {

            Id = values[0];
            Name = values[1];
            RoomId = values[2];
            NewRoomId = values[3];
            Quantity = int.Parse(values[4]);
            dateTime = DateTime.Parse(values[5]);
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id,
                Name,
                RoomId,
                NewRoomId,
                Quantity.ToString(),
                dateTime.ToString()
            };
            return csvValues;
        }
        //public string[] oneToCSV()
        //{
        //    string[] csvValues =
        //    {
        //        Name,
        //        NewRoomId,
        //        Quantity.ToString(),
        //        dateTime.ToString()
        //    };
        //    return csvValues;
        //}
    }
}
