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

        public RequestForSupplyEquipmentService(RequestForSupplyEquipmentRepository requestForSupplyEquipmentRepository)
        {
            this.requestForSupplyEquipmentRepository = requestForSupplyEquipmentRepository;
        }
        public List<RequestForSupplyEquipment> GetAllRequests()
        {
            return requestForSupplyEquipmentRepository.GetAllRequests();
        }
        public RequestForSupplyEquipment GetRequestById(String equipmentId)
        {
            return requestForSupplyEquipmentRepository.GetRequestById(equipmentId);
        }
        public Boolean DeleteRequest(String equipmentName)
        {
            return requestForSupplyEquipmentRepository.DeleteRequest(equipmentName);
        }
        public RequestForSupplyEquipment CreateRequest(String equipmentId, String equipmentName, int quantityToProcured)
        {
            
            if(GetRequestById(equipmentId) == null)
            {
                DateTime createdDate = DateTime.Now;
                return requestForSupplyEquipmentRepository.CreateRequest(equipmentName, equipmentId, quantityToProcured, createdDate);
            }
            else
            {
                return null;
            }
        }


    }
}
