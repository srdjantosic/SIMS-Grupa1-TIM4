using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Model
{
    public class RequestForSupplyEquipment : Serializable
    {
        public String EquipmentName { get; set; }
        public String EquipmentId { get; set; }
        public int QuantityToProcured { get; set; }
        public DateTime CreateDate { get; set; }

        public RequestForSupplyEquipment() { }
        public RequestForSupplyEquipment(String equipmentName, String equipmentId, int quantityToProcured, DateTime createDate)
        {
            this.EquipmentName = equipmentName;
            this.EquipmentId = equipmentId;
            this.QuantityToProcured = quantityToProcured;
            this.CreateDate = createDate;
        }
        public void fromCSV(string[] values)
        {

            EquipmentId = values[0];
            EquipmentName = values[1];
            QuantityToProcured = int.Parse(values[2]);
            CreateDate = DateTime.Parse(values[3]);

        }
        public string[] toCSV()
        {
            string[] csvValues =
            {
                EquipmentId,
                EquipmentName,
                QuantityToProcured.ToString(),
                CreateDate.ToString()

            };
            return csvValues;
        }
    }
}
