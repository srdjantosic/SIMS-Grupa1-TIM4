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
        private SpendableEquipmentRequestService spendableEquipmentRequestService;
        public EquipmentService(EquipmentRepository equipmentRepository,EquipmentToMoveRepository equipmentToMoveRepository, EquipmentToMoveService equipmentToMoveService)
        {
            this.equipmentRepository = equipmentRepository;
            this.equipmentToMoveRepository = equipmentToMoveRepository;
            this.equipmentToMoveService = equipmentToMoveService;
        }

        public EquipmentService(EquipmentRepository equipmentRepository, SpendableEquipmentRequestService spendableEquipmentRequestService)
        {
            this.equipmentRepository = equipmentRepository;
            this.spendableEquipmentRequestService = spendableEquipmentRequestService;
        }

        public List<Equipment> GetEquipment()
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
            return equipmentRepository.GetEquipment(); 

        }

        public List<Equipment> GetAllSpendableEquipment()
        {
            UpdateRequestedEquipment();

            List<Equipment> spendableEquipment = new List<Equipment>();
            foreach(Equipment equipment in equipmentRepository.GetEquipment())
            {
                if(equipment.EquipmentType == Equipment.EquipmentTypes.Spendable)
                {
                    spendableEquipment.Add(equipment);
                }
            }
            return spendableEquipment;
        }
        public void UpdateRequestedEquipment()
        {
            foreach(SpendableEquipmentRequest request in spendableEquipmentRequestService.GetAllRequests())
            {
                if(DateTime.Compare(request.CreateDate.AddDays(ProcurementDeadline).Date, DateTime.Now.Date) <= 0)
                {
                    Equipment equipment = GetEquipment(request.EquipmentId);
                    if(equipment != null)
                    {
                        UpdateEquipment(equipment.Name, equipment.Id, equipment.EquipmentType, equipment.Quantity + request.Quantity, equipment.RoomId);
                        spendableEquipmentRequestService.DeleteRequest(request.EquipmentName);
                    }
                    else
                    {
                        CreateEquipment(request.EquipmentId, request.EquipmentName, request.Quantity);
                        spendableEquipmentRequestService.DeleteRequest(request.EquipmentName);
                    }
                }
            }
        }

        public Boolean UpdateEquipment(String name, String id, Equipment.EquipmentTypes equipmentType, int quantity, String roomId)
        {
            return equipmentRepository.UpdateEquipment(id, name, equipmentType, quantity, roomId);
        }

        public Equipment CreateEquipment(String id, String name, int quantity)
        {
            return equipmentRepository.CreateEquipment(id, name, Equipment.EquipmentTypes.Spendable, quantity, " ");
        }
        public Equipment GetEquipment(String id)
        {
            return equipmentRepository.GetEquipment(id);
        }

    }
}
