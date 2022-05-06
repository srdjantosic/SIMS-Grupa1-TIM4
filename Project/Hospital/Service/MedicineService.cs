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

        // ZAVRSI OVO TOSICU - ovaj posa jedino ti mozes da zavrsis
        //public Medicine createMedicine(string name, string manufacturer, DateTime expiringDate, string components, string instructionsForUse) { }

        public Boolean updateMedicineStatus(string name)
        {
            return medicineRepository.updateMedicineStatus(name);
        }

        public List<Medicine> showMedicines()
        {
            return medicineRepository.showMedicines();
        }

        public Medicine getMedicine(string name)
        {
            return medicineRepository.getMedicine(name);
        }
    }
}
