using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Service;
using Project.Hospital.Model;

namespace Project.Hospital.Controller
{
    public class EquipmentController
    {
        private EquipmentService equipmentService;
        public EquipmentController(EquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }
        public List<Equipment> ShowEquipment()
        {
            return equipmentService.ShowEquipment();
        }
        public List<Equipment> GetAllSpendableEquipment()
        {
            return equipmentService.GetAllSpendableEquipment();
        }
        public Boolean UpdateEquipment(String name, String id, Equipment.EquipmentTypes equipmentType, int quantity, String roomId)
        {
            return equipmentService.UpdateEquipment(name, id, equipmentType, quantity, roomId);
        }
    }
}
