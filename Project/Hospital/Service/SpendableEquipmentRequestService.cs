using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.Repository;

namespace Project.Hospital.Service
{
    public class SpendableEquipmentRequestService
    {
        private SpendableEquipmentRequestRepository spendableEquipmentRequestRepository;

        public SpendableEquipmentRequestService(SpendableEquipmentRequestRepository spendableEquipmentRequestRepository)
        {
            this.spendableEquipmentRequestRepository = spendableEquipmentRequestRepository;
        }
        public List<SpendableEquipmentRequest> GetAllRequests()
        {
            return spendableEquipmentRequestRepository.GetAllRequests();
        }
        public SpendableEquipmentRequest GetRequestById(String equipmentId)
        {
            return spendableEquipmentRequestRepository.GetRequestById(equipmentId);
        }
        public Boolean DeleteRequest(String equipmentName)
        {
            return spendableEquipmentRequestRepository.DeleteRequest(equipmentName);
        }
        public SpendableEquipmentRequest CreateRequest(String equipmentId, String equipmentName, int quantity)
        {
            
            if(GetRequestById(equipmentId) == null)
            {
                DateTime createdDate = DateTime.Now;
                return spendableEquipmentRequestRepository.CreateRequest(equipmentName, equipmentId, quantity, createdDate);
            }
            else
            {
                return null;
            }
        }


    }
}
