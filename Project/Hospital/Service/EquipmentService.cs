using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Repository;
using Project.Hospital.Model;  

namespace Project.Hospital.Service
{
    public class EquipmentService
    {
        private EquipmentRepository equipmentRepository;
        private EquipmentToMoveRepository equipmentToMoveRepository;
        private EquipmentToMoveService equipmentToMoveService;
        public EquipmentService(EquipmentRepository equipmentRepository,EquipmentToMoveRepository equipmentToMoveRepository, EquipmentToMoveService equipmentToMoveService)
        {
            this.equipmentRepository = equipmentRepository;
            this.equipmentToMoveRepository = equipmentToMoveRepository;
            this.equipmentToMoveService = equipmentToMoveService;
        }

        public List<Equipment> ShowEquipment()
        {
            
            List<EquipmentToMove> equipmentsToMove = equipmentToMoveRepository.ShowEquipment();
            if (equipmentsToMove.Count != 0)
            {
                foreach (EquipmentToMove e in equipmentsToMove)
                {
                    if (e.dateTime.Date.Equals(DateTime.Now.Date))
                    {
                        Equipment equipment = equipmentRepository.GetEquipment(e.Id);
                        equipmentToMoveService.MoveTo(equipment, e.Id, e.RoomId, e.Name, e.Quantity, e.dateTime, e.NewRoomId);
                    }
                }
            }
            return equipmentRepository.ShowEquipment(); 

        }
    }
}
