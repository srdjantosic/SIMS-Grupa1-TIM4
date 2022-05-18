using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Model
{
    public class RequestForSupplyEquipment : Serializable
    {
        public String Name { get; set; }
        public String Id { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }

        public RequestForSupplyEquipment() { }
        public RequestForSupplyEquipment(String name, String id, int quantity, DateTime createDate)
        {
            this.Name = name;
            this.Id = id;
            this.Quantity = quantity;
            this.CreateDate = createDate;
        }
        public void fromCSV(string[] values)
        {

            Id = values[0];
            Name = values[1];
            Quantity = int.Parse(values[2]);
            CreateDate = DateTime.Parse(values[3]);

        }
        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id,
                Name,
                Quantity.ToString(),
                CreateDate.ToString()

            };
            return csvValues;
        }
    }
}
