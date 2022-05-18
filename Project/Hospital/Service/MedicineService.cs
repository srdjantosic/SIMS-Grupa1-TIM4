using Project.Hospital.Model;
using Project.Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Service
{
    public class MedicineService
    {

        private MedicineRepository medicineRepository;
        private const string NOT_FOUND_ERROR = "Medicine with {0}:{1} can not be found!";

        public MedicineService(MedicineRepository medicineRepository)
        {
            this.medicineRepository = medicineRepository;
        }

        //TODO
        public Boolean updateMedicineStatus(string name)
        {
            return medicineRepository.updateMedicineStatus(name);
        }

        //TODO
        public Boolean setReasonForDeclining(string name, string reason)
        {
            return medicineRepository.setReasonForDeclining(name, reason);
        }


        public List<Medicine> showMedicines()
        {
            return medicineRepository.showMedicines();
        }

        //TODO
        public List<Medicine> showUnverifiedMedicines()
        {
            List<Medicine> medicines = new List<Medicine>();

            foreach(Medicine medicine in showMedicines())
            {
                if(medicine.isActive == false)
                {
                    medicines.Add(medicine);
                }
            }
            return medicines;
        }

        public Medicine getMedicine(string name)
        {
            return medicineRepository.getMedicine(name);
        }
    }
}
