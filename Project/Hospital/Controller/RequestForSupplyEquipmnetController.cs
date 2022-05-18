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
        public RequestForSupplyEquipment GetRequestById(String id)
        {
            return requestForSupplyEquipmentService.GetRequestById(id);
        }
        public Boolean DeleteRequest(String name)
        {
            return requestForSupplyEquipmentService.DeleteRequest(name);
        }
        public RequestForSupplyEquipment CreateRequest(String id, String name, int quantity)
        {
            return requestForSupplyEquipmentService.CreateRequest(id, name, quantity);
        }
    }
}
