using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Model
{
    public class SpendableEquipmentRequest : Serializable
    {
        public String EquipmentName { get; set; }
        public String EquipmentId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }

        public SpendableEquipmentRequest() { }
        public SpendableEquipmentRequest(String equipmentName, String equipmentId, int quantity, DateTime createDate)
        {
            this.EquipmentName = equipmentName;
            this.EquipmentId = equipmentId;
            this.Quantity = quantity;
            this.CreateDate = createDate;
        }
        public void fromCSV(string[] values)
        {

            EquipmentId = values[0];
            EquipmentName = values[1];
            Quantity = int.Parse(values[2]);
            CreateDate = DateTime.Parse(values[3]);

        }
        public string[] toCSV()
        {
            string[] csvValues =
            {
                EquipmentId,
                EquipmentName,
                Quantity.ToString(),
                CreateDate.ToString()

            };
            return csvValues;
        }
    }
}
