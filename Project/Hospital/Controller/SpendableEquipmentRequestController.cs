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
        public SpendableEquipmentRequest GetRequestById(String equipmentId)
        {
            return spendableEquipmentRequestService.GetRequestById(equipmentId);
        }
        public Boolean DeleteRequest(String equipmentName)
        {
            return spendableEquipmentRequestService.DeleteRequest(equipmentName);
        }
        public SpendableEquipmentRequest CreateRequest(String equipmentId, String equipmentName, int quantity)
        {
            return spendableEquipmentRequestService.CreateRequest(equipmentId, equipmentName, quantity);
        }
    }
}
