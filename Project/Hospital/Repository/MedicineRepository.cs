using Project.Hospital.Exception;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Repository
{
    public class MedicineRepository
    {
        private const string NOT_FOUND_ERROR = "Medicine with {0}:{1} can not be found!";
        private const string fileName = "medicine.txt";
        public Medicine CreateMedicine(string name, string manufacturer, DateTime expiringDate, string components, string instructionsForUse)
        {
            Serializer<Medicine> medicineSerializer = new Serializer<Medicine>();
            Medicine medicine = new Medicine(name, manufacturer, expiringDate, components, instructionsForUse);
            medicineSerializer.oneToCSV(fileName, medicine);
            return medicine;
        }

        //TODO
        public Boolean UpdateMedicineStatus(string name)
        {
            List<Medicine> medicines = ShowMedicines();

            foreach (Medicine medicine in medicines)
            {
                if (medicine.Name.Equals(name))
                {
                    medicine.isActive = true;
                    Serializer<Medicine> medicineSerializer = new Serializer<Medicine>();
                    medicineSerializer.toCSV(fileName, medicines);
                    return true;
                }
            }
            return false;
        }

        //TODO
        public Boolean SetReasonForDeclining(string name, string reason)
        {
            List<Medicine> medicines = ShowMedicines();

            foreach (Medicine medicine in medicines)
            {
                if (medicine.Name.Equals(name))
                {
                    medicine.ReasonForDecline = reason;
                    Serializer<Medicine> medicineSerializer = new Serializer<Medicine>();
                    medicineSerializer.toCSV(fileName, medicines);
                    return true;
                }
            }
            return false;
        }

        public List<Medicine> ShowMedicines()
        {
            Serializer<Medicine> medicineSerializer = new Serializer<Medicine>();
            List<Medicine> medicines = medicineSerializer.fromCSV(fileName);
            return medicines;
        }

        public Medicine GetMedicine(string name)
        {
            try
            {
                {
                    return ShowMedicines().SingleOrDefault(medicine => medicine.Name.Equals(name));
                }
            }
            catch (ArgumentException)
            {
                {
                    throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "name", name));
                }
            }
        }
    }
}
