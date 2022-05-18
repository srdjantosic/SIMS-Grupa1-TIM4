using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.Repository;

namespace Project.Hospital.Service
{
    public class RequestForSupplyEquipmentService
    {
        private RequestForSupplyEquipmentRepository requestForSupplyEquipmentRepository;
        //private EquipmentService equipmentService;

        public RequestForSupplyEquipmentService(RequestForSupplyEquipmentRepository requestForSupplyEquipmentRepository)
        {
            this.requestForSupplyEquipmentRepository = requestForSupplyEquipmentRepository;
        }
        public List<RequestForSupplyEquipment> GetAllRequests()
        {
            return requestForSupplyEquipmentRepository.GetAllRequests();
        }
        public RequestForSupplyEquipment GetRequestById(String id)
        {
            return requestForSupplyEquipmentRepository.GetRequestById(id);
        }
        public Boolean DeleteRequest(String name)
        {
            return requestForSupplyEquipmentRepository.DeleteRequest(name);
        }
        public RequestForSupplyEquipment CreateRequest(String id, String name, int quantity)
        {
            //Equipment procurementEquipment = equipmentService.GetSpendableEquipmentByName(name);
            RequestForSupplyEquipment requestForSupply = GetRequestById(id);

            if(requestForSupply == null)
            {
                DateTime createdDate = DateTime.Now;
                return requestForSupplyEquipmentRepository.CreateRequest(name, id, quantity, createdDate);
            }
            else
            {
                return null;
            }
        }


    }
}
