using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Repository
{
    public class RequestForSupplyEquipmentRepository
    {
        public RequestForSupplyEquipmentRepository() { }
        public List<RequestForSupplyEquipment> GetAllRequests()
        {
            Serializer<RequestForSupplyEquipment> requestSerializer = new Serializer<RequestForSupplyEquipment>();
            List<RequestForSupplyEquipment> requests = requestSerializer.fromCSV("requests.txt");
            return requests;
        }
        public RequestForSupplyEquipment CreateRequest(String equipmentName, String equipmentId, int quantityToProcured, DateTime createDate)
        {
            Serializer<RequestForSupplyEquipment> requestSerializer = new Serializer<RequestForSupplyEquipment>();
            RequestForSupplyEquipment request = new RequestForSupplyEquipment(equipmentName, equipmentId, quantityToProcured, createDate);
            requestSerializer.oneToCSV("requests.txt", request);
            return request;
        }
        public RequestForSupplyEquipment GetRequestById(String equipmentId)
        {
            return GetAllRequests().SingleOrDefault(request => request.EquipmentId == equipmentId);
        }

        public Boolean DeleteRequest(String equipmentName)
        {
            List<RequestForSupplyEquipment> requests = GetAllRequests();

            foreach(RequestForSupplyEquipment request in requests)
            {
                if(request.EquipmentName == equipmentName)
                {
                    if (requests.Remove(request))
                    {
                        Serializer<RequestForSupplyEquipment> requestSerializer = new Serializer<RequestForSupplyEquipment>();
                        requestSerializer.toCSV("requests.txt", requests);
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
    }
}
