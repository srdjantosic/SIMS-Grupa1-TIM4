using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Exception;
using Project.Hospital.Model;
using Project.Hospital.Repository.IRepository;

namespace Project.Hospital.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private const string NOT_FOUND_ERROR = "Equipments with {0}:{1} can not be found!";
        private const string fileName = "equipment.txt";
        public EquipmentRepository() { }
        public List<Equipment> GetAll()
        {
            Serializer<Equipment> equipmentSerializer = new Serializer<Equipment>();
            return equipmentSerializer.fromCSV(fileName);
        }
        public Equipment Create(String id, String name, Equipment.EquipmentTypes equipmentType, int quantity, String roomId)
        {
            Serializer<Equipment> equipmentSerializer = new Serializer<Equipment>();
            Equipment equipment = new Equipment(id, name, equipmentType, quantity, roomId);
            equipmentSerializer.oneToCSV(fileName, equipment);
            return equipment;
        }
        public Boolean Delete(String name)
        {
            List<Equipment> allEquipment = GetAll();
            Equipment equipment = allEquipment.SingleOrDefault(equipment => equipment.Name == name);
            if (equipment == null || allEquipment.Remove(equipment))
            {
                Serializer<Equipment> equipmentSerializer = new Serializer<Equipment>();
                equipmentSerializer.toCSV(fileName, allEquipment);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Save(List<Equipment> equipments)
        {
            Serializer<Equipment> roomSerializer = new Serializer<Equipment>();
            roomSerializer.toCSV(fileName, equipments);
        }
        public Equipment GetOne(String id)
        {
            return GetAll().SingleOrDefault(equipment => equipment.Id == id);

        }
    }
}
