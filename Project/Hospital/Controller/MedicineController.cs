using Project.Hospital.Model;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Controller
{
    public class MedicineController
    {

        private MedicineService medicineService;

        public MedicineController (MedicineService medicineService)
        {
            this.medicineService = medicineService;
        }

        // ZAVRSI OVO TOSICU - ovaj posa jedino ti mozes da zavrsis
        //public Medicine createMedicine(string name, string manufacturer, DateTime expiringDate, string components, string instructionsForUse) { }

        public Boolean updateMedicineStatus(string name)
        {
            return medicineService.updateMedicineStatus(name);
        }

        public List<Medicine> showMedicines()
        {
            return medicineService.showMedicines();
        }

        public Medicine getMedicine(string name)
        {
            return medicineService.getMedicine(name);
        }
    }
}
