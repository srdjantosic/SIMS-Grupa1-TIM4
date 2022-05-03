using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Model
{
    public  class Equipment : Serializable
    {
        public String Name { get; set; }
        public String Id { get; set; }
        public enum EquipmentTypes{
            Permanent,
            Spendable
        }
        public  EquipmentTypes EquipmentType { get; set; }
        public int Quantity { get; set; }

        public String RoomId { get; set; }

        public Equipment() { }
        public Equipment(String id, String Name, EquipmentTypes EquipmentType,int Quantity,String RoomId)
        {
            this.Name = Name;
            this.EquipmentType = EquipmentType;
            this.Quantity =Quantity;
            this.RoomId = RoomId;
            this.Id = id;
        }

        public void fromCSV(string[] values)
        {

            Id = values[0];
            Name = values[1];
            EquipmentType = (EquipmentTypes)Enum.Parse(typeof(EquipmentTypes), values[2]);
            Quantity = int.Parse(values[3]);
            RoomId = values[4];
        
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id,
                Name,
                EquipmentType.ToString(),
                Quantity.ToString(),
                RoomId
                
            };
            return csvValues;
        }

    }
}

