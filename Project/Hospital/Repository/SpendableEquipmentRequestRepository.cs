using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.Repository.IRepository;

namespace Project.Hospital.Repository
{
    public class SpendableEquipmentRequestRepository : ISpendableEquipmentRequestRepository
    {
        private const string fileName = "requests.txt";
        public SpendableEquipmentRequestRepository() { }
        public List<SpendableEquipmentRequest> GetAll()
        {
            Serializer<SpendableEquipmentRequest> requestSerializer = new Serializer<SpendableEquipmentRequest>();
            return requestSerializer.fromCSV(fileName);
        }
        public SpendableEquipmentRequest Create(String equipmentName, String equipmentId, int quantity, DateTime createDate)
        {
            Serializer<SpendableEquipmentRequest> requestSerializer = new Serializer<SpendableEquipmentRequest>();
            SpendableEquipmentRequest request = new SpendableEquipmentRequest(equipmentName, equipmentId, quantity, createDate);
            requestSerializer.oneToCSV(fileName, request);
            return request;
        }
        public SpendableEquipmentRequest GetOne(String equipmentId)
        {
            return GetAll().SingleOrDefault(request => request.EquipmentId == equipmentId);
        }

        public Boolean Delete(String equipmentName)
        {
            List<SpendableEquipmentRequest> requests = GetAll();
            SpendableEquipmentRequest request = requests.SingleOrDefault(request => request.EquipmentName == equipmentName);
            if(request != null && requests.Remove(request))
            {
                Serializer<SpendableEquipmentRequest> requestSerializer = new Serializer<SpendableEquipmentRequest>();
                requestSerializer.toCSV(fileName, requests);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
