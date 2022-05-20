using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Service;
using Project.Hospital.Model;

namespace Project.Hospital.Controller
{
    public class RequestForSupplyEquipmnetController
    {
        private RequestForSupplyEquipmentService requestForSupplyEquipmentService;

        public RequestForSupplyEquipmnetController(RequestForSupplyEquipmentService requestForSupplyEquipmentService)
        {
            this.requestForSupplyEquipmentService = requestForSupplyEquipmentService;
        }
        public RequestForSupplyEquipment GetRequestById(String equipmentId)
        {
            return requestForSupplyEquipmentService.GetRequestById(equipmentId);
        }
        public Boolean DeleteRequest(String equipmentName)
        {
            return requestForSupplyEquipmentService.DeleteRequest(equipmentName);
        }
        public RequestForSupplyEquipment CreateRequest(String equipmentId, String equipmentName, int quantityToProcured)
        {
            return requestForSupplyEquipmentService.CreateRequest(equipmentId, equipmentName, quantityToProcured);
        }
    }
}
