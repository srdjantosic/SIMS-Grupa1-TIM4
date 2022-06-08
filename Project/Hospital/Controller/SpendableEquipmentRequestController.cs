using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Service;
using Project.Hospital.Model;

namespace Project.Hospital.Controller
{
    public class SpendableEquipmentRequestController
    {
        private SpendableEquipmentRequestService spendableEquipmentRequestService;

        public SpendableEquipmentRequestController(SpendableEquipmentRequestService spendableEquipmentRequestService)
        {
            this.spendableEquipmentRequestService = spendableEquipmentRequestService;
        }
        public List<SpendableEquipmentRequest> GetAll()
        {
            return spendableEquipmentRequestService.GetAll();
        }
        public SpendableEquipmentRequest GetOne(String equipmentId)
        {
            return spendableEquipmentRequestService.GetOne(equipmentId);
        }
        public Boolean Delete(String equipmentName)
        {
            return spendableEquipmentRequestService.Delete(equipmentName);
        }
        public SpendableEquipmentRequest Create(String equipmentId, String equipmentName, int quantity)
        {
            return spendableEquipmentRequestService.Create(equipmentId, equipmentName, quantity);
        }
    }
}
