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

        public MedicineController(MedicineService medicineService)
        {
            this.medicineService = medicineService;
        }

        //TODO
        public Boolean updateMedicineStatus(string name)
        {
            return medicineService.updateMedicineStatus(name);
        }

        //TODO
        public Boolean setReasonForDeclining(string name, string reason)
        {
            return medicineService.setReasonForDeclining(name, reason);
        }

        public List<Medicine> showMedicines()
        {
            return medicineService.showMedicines();
        }

        //TODO
        public List<Medicine> showUnverifiedMedicines()
        {
            return medicineService.showUnverifiedMedicines();
        }

        public Medicine getMedicine(string name)
        {
            return medicineService.getMedicine(name);
        }
    }
}
