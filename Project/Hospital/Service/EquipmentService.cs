using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Repository;
using Project.Hospital.Model;
using Project.Hospital.Repository.IRepository;

namespace Project.Hospital.Service
{
    public class EquipmentService
    {
        private const double ProcurementDeadline = 3;
        private IEquipmentRepository iEquipmentRepo;
        private SpendableEquipmentRequestService spendableEquipmentRequestService;
        public EquipmentService(IEquipmentRepository iEquipmentRepo, SpendableEquipmentRequestService spendableEquipmentRequestService)
        {
            this.iEquipmentRepo = iEquipmentRepo;
            this.spendableEquipmentRequestService = spendableEquipmentRequestService;
        }
        public List<Equipment> GetAll()
        {
            return iEquipmentRepo.GetAll();

        }
        public List<Equipment> GetAllSpendableEquipment()
        {
            UpdateRequestedEquipment();

            List<Equipment> spendableEquipment = new List<Equipment>();
            foreach(Equipment equipment in GetAll())
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
            foreach(SpendableEquipmentRequest request in spendableEquipmentRequestService.GetAll())
            {
                if(DateTime.Compare(request.CreateDate.AddDays(ProcurementDeadline).Date, DateTime.Now.Date) <= 0)
                {
                    Equipment equipment = GetOne(request.EquipmentId);
                    if(equipment != null)
                    {
                        Update(equipment.Id, equipment.Quantity + request.Quantity);
                        spendableEquipmentRequestService.Delete(request.EquipmentName);
                    }
                    else
                    {
                        Create(request.EquipmentId, request.EquipmentName, request.Quantity);
                        spendableEquipmentRequestService.Delete(request.EquipmentName);
                    }
                }
            }
        }

        public Boolean Update(String id, int quantity)
        {
            List<Equipment> allEquipment = GetAll();
            foreach(Equipment equipment in allEquipment)
            {
                if(equipment.Id == id)
                {
                    equipment.Quantity = quantity;
                    iEquipmentRepo.Save(allEquipment);
                    return true;
                }
            }
            return false;
        }

        public Equipment Create(String id, String name, int quantity)
        {
            return iEquipmentRepo.Create(id, name, Equipment.EquipmentTypes.Spendable, quantity, "/");
        }
        public Equipment GetOne(String id)
        {
            return iEquipmentRepo.GetOne(id);
        }

    }
}
