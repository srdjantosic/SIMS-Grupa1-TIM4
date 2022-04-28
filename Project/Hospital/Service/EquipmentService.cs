using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Repository;
using Project.Hospital.Model;  

namespace Project.Hospital.Service
{
    public class EquipmentService
    {
        private EquipmentRepository equipmentRepository;
        public EquipmentService(EquipmentRepository equipmentRepository)
        {
            this.equipmentRepository = equipmentRepository;
        }

        public List<Equipment> ShowEquipment()
        {
            return equipmentRepository.ShowEquipment();
        }
    }
}
