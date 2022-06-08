using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Repository.IRepository
{
    public interface ISpendableEquipmentRequestRepository
    {
        public List<SpendableEquipmentRequest> GetAll();
        public SpendableEquipmentRequest Create(String equipmentName, String equipmentId, int quantity, DateTime createDate);
        public SpendableEquipmentRequest GetOne(String equipmentId);
        public Boolean Delete(String equipmentName);
    }
}
