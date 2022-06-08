using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Repository.IRepository
{
    public interface IEquipmentRepository
    {
        public List<Equipment> GetAll();
        public Equipment Create(String id, String name, Equipment.EquipmentTypes equipmentType, int quantity, String roomId);
        public Boolean Delete(String name);
        public void Save(List<Equipment> equipment);
        public Equipment GetOne(String id);
    }
}
