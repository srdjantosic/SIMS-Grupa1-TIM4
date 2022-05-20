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
        public Boolean Verify(string name)
        {
            return medicineRepository.Verify(name);
        }

        //TODO
        public Boolean SetDecliningReason(string name, string reason)
        {
            return medicineRepository.SetDecliningReason(name, reason);
        }


        public List<Medicine> ShowMedicines()
        {
            return medicineRepository.ShowMedicines();
        }

        //TODO
        public List<Medicine> ShowUnverifiedMedicines()
        {
            List<Medicine> medicines = new List<Medicine>();

            foreach(Medicine medicine in ShowMedicines())
            {
                if(medicine.isActive == false)
                {
                    medicines.Add(medicine);
                }
            }
            return medicines;
        }

        public Medicine GetMedicine(string name)
        {
            return medicineRepository.GetMedicine(name);
        }
    }
}
