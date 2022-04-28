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
        public enum EquipmentTypes        {
            Permanent,
            Spendable
        }
        public  EquipmentTypes EquipmentType { get; set; }
        public int Quantity { get; set; }

        public String RoomId { get; set; }

        public Equipment() { }
        public Equipment(String Name, EquipmentTypes EquipmentType,int Quantity,String RoomId)
        {
            this.Name = Name;
            this.EquipmentType = EquipmentType;
            this.Quantity =Quantity;
            this.RoomId = RoomId;
        }

        public void fromCSV(string[] values)
        {


            Name = values[0];
            EquipmentType = (EquipmentTypes)Enum.Parse(typeof(EquipmentTypes), values[1]);
            Quantity = int.Parse(values[2]);
            RoomId = values[3];
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Name,
                EquipmentType.ToString(),
                Quantity.ToString(),
                RoomId
            };
            return csvValues;
        }

    }
}

