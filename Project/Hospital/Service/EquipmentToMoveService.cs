using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Repository;
using Project.Hospital.Model;
using Project.Hospital.Exception;

namespace Project.Hospital.Service
{
    public class EquipmentToMoveService
    {
        private EquipmentToMoveRepository equipmentToMoveRepository;
        private EquipmentRepository equipmentRepository;
        private const string NOT_FOUND_ERROR = "Equipment with {0}:{1} can not be found!";
        public EquipmentToMoveService(EquipmentToMoveRepository equipmentToMoveRepository, EquipmentRepository equipmentRepository)
        {
            this.equipmentToMoveRepository = equipmentToMoveRepository;
            this.equipmentRepository = equipmentRepository;
        }

        public void MoveTo(Equipment e, String Id, String OldRoomId, String Name, int Quantity, DateTime dateTime, String newRoomID)
        {
            int oldQ = e.Quantity;
            if (e.EquipmentType == Equipment.EquipmentTypes.Spendable)
            {
                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "Not possible"));
            }
            else
            {
                if ((e.Quantity - Quantity) < 0)
                {
                    throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "Not possible"));
                }
                else if ((e.Quantity - Quantity) == 0)
                {
                    equipmentRepository.UpdateEquipment(Id, Name, Equipment.EquipmentTypes.Permanent, Quantity, newRoomID);
                }
                else
                {

                    equipmentRepository.UpdateEquipment(Id, Name, Equipment.EquipmentTypes.Permanent, oldQ - Quantity, OldRoomId);

                    equipmentRepository.CreateEquipment(" ", Name, Equipment.EquipmentTypes.Permanent, Quantity, newRoomID);
                }
            }

        }
        public void ChangeEquipment(String Id, String OldRoomId, String Name, int Quantity, DateTime dateTime, String newRoomID) {

            Equipment e = this.equipmentRepository.GetEquipment(Id);
            if (dateTime.Date.Equals(DateTime.Now.Date))
            {
                MoveTo(e, Id, OldRoomId, Name, Quantity, dateTime, newRoomID);
           
            //int oldQ = e.Quantity;
            //if (e.EquipmentType == Equipment.EquipmentTypes.Spendable)
            //{
            //    throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "Not possible"));
            //}
            //else
            //{
            //    if ((e.Quantity - Quantity) < 0)
            //    {
            //        throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "Not possible"));
            //    }
            //    else if ((e.Quantity - Quantity) == 0)
            //    {
            //        equipmentRepository.UpdateEquipment(Id, Name, Equipment.EquipmentTypes.Permanent, Quantity, newRoomID);
            //    }
            //    else
            //    {

            //        equipmentRepository.UpdateEquipment(Id, Name, Equipment.EquipmentTypes.Permanent, oldQ - Quantity, OldRoomId);

            //        equipmentRepository.CreateEquipment(Name, Equipment.EquipmentTypes.Permanent, Quantity, newRoomID);
            //    }
            //    }
            }
            else
            {
                equipmentToMoveRepository.ChangeEquipment(Id, OldRoomId, Name, Quantity, dateTime, newRoomID);
            }


        }
        public List<EquipmentToMove> ShowEquipment()
        {
            return equipmentToMoveRepository.ShowEquipment();
        }
    }
}
