using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Repository
{
    public class EquipmentToMoveRepository
    {
        public EquipmentToMoveRepository() { }

        public EquipmentToMove changeEquipment(String Id, String OldRoomId, String Name, int Quantity, DateTime dateTime,String newRoomID)
        {
            
            Serializer<EquipmentToMove> equipmentToMoveSerializer = new Serializer<EquipmentToMove>();
            EquipmentToMove equipmentToMove = new EquipmentToMove(Id, Name,OldRoomId, newRoomID,Quantity, dateTime);
            equipmentToMoveSerializer.oneToCSV("equipmentToMove.txt", equipmentToMove);

            return equipmentToMove;
        }
        public List<EquipmentToMove> ShowEquipment()
        {
            Serializer<EquipmentToMove> equipmentToMoveSerializer = new Serializer<EquipmentToMove>();
            List<EquipmentToMove>  equipmentsToMove = equipmentToMoveSerializer.fromCSV("equipmentToMove.txt");
            return equipmentsToMove;
        }

    }
}
