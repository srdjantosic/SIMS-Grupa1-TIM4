using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Repository
{
    public class SpendableEquipmentRequestRepository
    {
        private const string fileName = "requests.txt";
        public SpendableEquipmentRequestRepository() { }
        public List<SpendableEquipmentRequest> GetAllRequests()
        {
            Serializer<SpendableEquipmentRequest> requestSerializer = new Serializer<SpendableEquipmentRequest>();
            List<SpendableEquipmentRequest> requests = requestSerializer.fromCSV(fileName);
            return requests;
        }
        public SpendableEquipmentRequest CreateRequest(String equipmentName, String equipmentId, int quantity, DateTime createDate)
        {
            Serializer<SpendableEquipmentRequest> requestSerializer = new Serializer<SpendableEquipmentRequest>();
            SpendableEquipmentRequest request = new SpendableEquipmentRequest(equipmentName, equipmentId, quantity, createDate);
            requestSerializer.oneToCSV(fileName, request);
            return request;
        }
        public SpendableEquipmentRequest GetRequestById(String equipmentId)
        {
            return GetAllRequests().SingleOrDefault(request => request.EquipmentId == equipmentId);
        }

        public Boolean DeleteRequest(String equipmentName)
        {
            List<SpendableEquipmentRequest> requests = GetAllRequests();

            foreach(SpendableEquipmentRequest request in requests)
            {
                if(request.EquipmentName == equipmentName)
                {
                    if (requests.Remove(request))
                    {
                        Serializer<SpendableEquipmentRequest> requestSerializer = new Serializer<SpendableEquipmentRequest>();
                        requestSerializer.toCSV(fileName, requests);
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
    }
}
