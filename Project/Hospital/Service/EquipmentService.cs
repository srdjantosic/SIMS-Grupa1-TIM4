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
        public const double ProcurementDeadline = 3;

        private EquipmentRepository equipmentRepository;
        private EquipmentToMoveRepository equipmentToMoveRepository;
        private EquipmentToMoveService equipmentToMoveService;
        private RequestForSupplyEquipmentService requestForSupplyEquipmentService;
        public EquipmentService(EquipmentRepository equipmentRepository,EquipmentToMoveRepository equipmentToMoveRepository, EquipmentToMoveService equipmentToMoveService)
        {
            this.equipmentRepository = equipmentRepository;
            this.equipmentToMoveRepository = equipmentToMoveRepository;
            this.equipmentToMoveService = equipmentToMoveService;
        }

        public EquipmentService(EquipmentRepository equipmentRepository, RequestForSupplyEquipmentService requestForSupplyEquipmentService)
        {
            this.equipmentRepository = equipmentRepository;
            this.requestForSupplyEquipmentService = requestForSupplyEquipmentService;
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

        public List<Equipment> GetAllSpendableEquipment()
        {
            List<Equipment> spendableEquipment = new List<Equipment>();
            foreach(Equipment equipment in equipmentRepository.ShowEquipment())
            {
                if(equipment.EquipmentType == Equipment.EquipmentTypes.Spendable)
                {
                    spendableEquipment.Add(equipment);
                }
            }
            return UpdateRequestedEquipment(spendableEquipment);
        }
        public List<Equipment> UpdateRequestedEquipment(List<Equipment> spendableEquipment)
        {
            for (int i = 0; i < spendableEquipment.Count; i++)
            {
                RequestForSupplyEquipment request = requestForSupplyEquipmentService.GetRequestById(spendableEquipment[i].Id);
                if(request != null)
                {
                    if(request.CreateDate.AddDays(ProcurementDeadline).ToShortDateString() == DateTime.Now.ToShortDateString())
                    {
                        UpdateEquipment(spendableEquipment[i].Name, spendableEquipment[i].Id, spendableEquipment[i].EquipmentType, spendableEquipment[i].Quantity + request.Quantity, spendableEquipment[i].RoomId);
                        spendableEquipment[i].Quantity += request.Quantity; 
                        requestForSupplyEquipmentService.DeleteRequest(request.Name);
                    }
                }
            }
            return spendableEquipment;
        }

        public Boolean UpdateEquipment(String name, String id, Equipment.EquipmentTypes equipmentType, int quantity, String roomId)
        {
            return equipmentRepository.UpdateEquipment(id, name, equipmentType, quantity, roomId);
        }

    }
}
