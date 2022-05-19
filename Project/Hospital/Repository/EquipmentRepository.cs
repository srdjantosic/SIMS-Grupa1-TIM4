using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Exception;
using Project.Hospital.Model;

namespace Project.Hospital.Repository
{
    public class EquipmentRepository
    {
        private const string NOT_FOUND_ERROR = "Equipments with {0}:{1} can not be found!";
        public EquipmentRepository() { }
        public List<Equipment> ShowEquipment()
        {
           
            Serializer<Equipment> equipmentSerializer = new Serializer<Equipment>();
            List<Equipment>  equipments = equipmentSerializer.fromCSV("equipments.txt");
            return equipments;
        }
        public Equipment CreateEquipment(String Id, String Name, Equipment.EquipmentTypes equipmentType, int Quantity, String RoomId)
        {
            Serializer<Equipment> equipmentSerializer = new Serializer<Equipment>();
            Equipment equipment = new Equipment(Id, Name, equipmentType,Quantity,RoomId);
            equipmentSerializer.oneToCSV("equipments.txt", equipment);
            return equipment;
        }
        public Boolean DeleteEquipment(String name)
        {
            List<Equipment> equipments = new List<Equipment>();
            equipments = ShowEquipment();

            foreach (Equipment equipment in equipments)
            {
                if (equipment.Name == name)
                {
                    if (equipments.Remove(equipment))
                    {
                        Serializer<Equipment> equipmentSerializer = new Serializer<Equipment>();
                        equipmentSerializer.toCSV("equipments.txt", equipments);
                        return true;
                    }
                    else
                    {

                        return false;

                    }
                }
            }

            return false;


        }
        public Boolean UpdateEquipment(String Id, String Name, Equipment.EquipmentTypes equipmentType, int Quantity, String RoomId)
        {
            //List<Equipment> equipments = new List<Equipment>();
            List < Equipment >  equipments = ShowEquipment();
            foreach (Equipment equipment in equipments)
            {
                if (equipment.Id.Equals(Id))
                {
                    equipment.Name = Name;
                    equipment.EquipmentType = equipmentType;
                    equipment.RoomId = RoomId;
                    equipment.Quantity = Quantity;
                    Serializer<Equipment> roomSerializer = new Serializer<Equipment>();
                    roomSerializer.toCSV("equipments.txt", equipments);
                    return true;
                }

            }
            return false;

        }
        public Equipment GetEquipment(String id)
        {
            return ShowEquipment().SingleOrDefault(equipment => equipment.Id == id);

        }
    }
}
