using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Repository.IRepository;

namespace Project.Hospital.Service
{
    public class SpendableEquipmentRequestService
    {
        private ISpendableEquipmentRequestRepository iSpendableEquipmentRequestRepo;

        public SpendableEquipmentRequestService(ISpendableEquipmentRequestRepository iSpendableEquipmentRequestRepo)
        {
            this.iSpendableEquipmentRequestRepo = iSpendableEquipmentRequestRepo;
        }
        public List<SpendableEquipmentRequest> GetAll()
        {
            return iSpendableEquipmentRequestRepo.GetAll();
        }
        public SpendableEquipmentRequest GetOne(String equipmentId)
        {
            return iSpendableEquipmentRequestRepo.GetOne(equipmentId);
        }
        public Boolean Delete(String equipmentName)
        {
            return iSpendableEquipmentRequestRepo.Delete(equipmentName);
        }
        public SpendableEquipmentRequest Create(String equipmentId, String equipmentName, int quantity)
        {
            if(GetOne(equipmentId) == null)
            {
                DateTime createdDate = DateTime.Now;
                return iSpendableEquipmentRequestRepo.Create(equipmentName, equipmentId, quantity, createdDate);
            }
            else
            {
                return null;
            }
        }


    }
}
