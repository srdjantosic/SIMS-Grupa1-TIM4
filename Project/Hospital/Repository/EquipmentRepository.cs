using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
namespace Project.Hospital.Repository
{
    public class EquipmentRepository
    {
        private const string NOT_FOUND_ERROR = "Equipments with {0}:{1} can not be found!";
        public EquipmentRepository() { }
        public List<Equipment> ShowEquipment()
        {
            List<Equipment> equipments = new List<Equipment>();
            Serializer<Equipment> equipmentSerializer = new Serializer<Equipment>();
            equipments = equipmentSerializer.fromCSV("equipments.txt");
            return equipments;
        }
    }
}
