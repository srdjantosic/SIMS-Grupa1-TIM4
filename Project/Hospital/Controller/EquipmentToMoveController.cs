using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Service;
using Project.Hospital.Model;
namespace Project.Hospital.Controller
{
    public class EquipmentToMoveController
    {
        private EquipmentToMoveService equipmentToMoveService;


        public EquipmentToMoveController(EquipmentToMoveService equipmentToMoveService)
        {
            this.equipmentToMoveService = equipmentToMoveService;
        }
        public void ChangeEquipment(String Id, String oldRoomId, String Name, int Quantity, DateTime dateTime, String newRoomID) {
           //equipmentToMoveService.ChangeEquipment(Id, oldRoomId, Name, Quantity, dateTime, newRoomID); 
        }
        public List<EquipmentToMove> ShowEquipment()
        {
            return equipmentToMoveService.ShowEquipment();
        }
    }
}
